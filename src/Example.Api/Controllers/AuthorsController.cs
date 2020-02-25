using System;
using System.Collections.Generic;
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
        public IActionResult Get([FromQuery] AuthorsRequest request)
        {
            var authors = _repository.GetAuthors(request.SearchQuery, request.Page, request.HowMany);

            Request.Headers
                .AddPaginationMetadata(
                    authors.TotalCount,
                    authors.PageSize,
                    authors.CurrentPage,
                    authors.TotalPages);

            return Ok(authors);
        }

        [HttpGet("{authorId}", Name = "GetAuthor")]
        public IActionResult Get(Guid authorId)
        {
            var author = _repository.GetAuthor(authorId);

            var response = new
            {
                firstName = author.FirstName,
                lastName = author.LastName,
                links = CreateLinks(authorId)
            };

            return Ok(response);
        }

        [HttpPost(Name = "CreateAuthor")]
        public IActionResult Post([FromBody] CreateAuthorRequest request)
        {
            var author = new Core.Entities.Author
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            _repository.Insert(author);

            _repository.Save();

            var response = new
            {
                firstName = author.FirstName,
                lastName = author.LastName,
                links = CreateLinks(author.Id)
            };

            return CreatedAtRoute("GetAuthor", new { authorId = author.Id }, response);
        }

        [HttpDelete("{authorId}", Name = "DeleteAuthor")]
        public IActionResult Delete(Guid authorId) => Ok();

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
