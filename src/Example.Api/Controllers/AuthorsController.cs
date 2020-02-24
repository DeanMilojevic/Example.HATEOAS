using Example.Api.Extensions;
using Example.Api.Models;
using Example.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet]
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
    }
}
