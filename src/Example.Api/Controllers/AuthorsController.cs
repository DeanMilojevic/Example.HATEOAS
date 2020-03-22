using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Example.Api.Constants;
using Example.Api.Extensions;
using Example.Api.Models;
using Example.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsRepository _repository;

        public AuthorsController(IAuthorsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "GetAuthors")]
        [Produces(
            "application/vnd.test.hateoas+json",
            "application/json")]
        public IActionResult Get([FromQuery] AuthorsRequest request)
        {
            var authors = _repository.GetAuthors(request.SearchQuery, request.Page, request.HowMany);

            Response.Headers
                .AddPaginationMetadata(
                    authors.TotalCount,
                    authors.PageSize,
                    authors.CurrentPage,
                    authors.TotalPages);

            var requestedValues = request.Fields
                                        .Split(',')
                                        .Select(field => field.Trim())
                                        .Where(field => !string.IsNullOrEmpty(field))
                                        .ToArray();

            var mappedAuthors = authors.Select(author => 
            {
                IDictionary<string, object> mappedAuthor = requestedValues.Any() ?
                    author.ToResponse(requestedValues) :
                    author.ToResponse();

                mappedAuthor.Add("links", CreateLinks(author.Id));

                return mappedAuthor;
            });

            var response = new
            {
                value = mappedAuthors,
                links = new List<Link>
                {
                    new Link(HttpVerb.Get, "self", Url.Link("GetAuthors", request))
                }
            };

            return Ok(response);
        }

        [HttpGet("{authorId}", Name = "GetAuthor")]
        [Produces(
            "application/json",
            "application/vnd.test.hateoas+json")]
        public IActionResult Get([FromHeader(Name = "Accept")] string mediaType, Guid authorId, string fields = "")
        {
            if (!MediaTypeHeaderValue.TryParse(mediaType, out MediaTypeHeaderValue parsedMediaType))
            {
                return BadRequest();
            }

            var author = _repository.GetAuthor(authorId);

            if (author is null)
            {
                return NotFound();
            }

            var response = author.ToResponse() as IDictionary<string, object>;

            var includeLinks = parsedMediaType.MediaType.Contains("hateoas", StringComparison.InvariantCultureIgnoreCase);

            if (includeLinks)
            {
                response.Add("links", CreateLinks(author.Id));
            }
            
            return Ok(response);
        }

        [HttpPost(Name = "CreateAuthor")]
        [Produces(
            "application/vnd.test.hateoas+json")]
        public IActionResult Post([FromBody] CreateAuthorRequest request)
        {
            var author = new Core.Entities.Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            _repository.Insert(author);

            _repository.Save();

            var response = author.ToResponse() as IDictionary<string, object>;
            response.Add("links", CreateLinks(author.Id));

            return CreatedAtRoute("GetAuthor", new { authorId = author.Id }, response);
        }

        [HttpDelete("{authorId}", Name = "DeleteAuthor")]
        public IActionResult Delete(Guid authorId)
        {
            _repository.Delete(new Core.Entities.Author { Id = authorId });
            _repository.Save();

            return Ok();
        }

        private List<Link> CreateLinks(Guid authorId)
        {
            var links = new List<Link>
            {
                new Link(HttpVerb.Get, "self", Url.Link("GetAuthor", new { authorId })),
                new Link(HttpVerb.Delete, "delete_author", Url.Link("DeleteAuthor", new { authorId }))
            };

            return links;
        }
    }
}
