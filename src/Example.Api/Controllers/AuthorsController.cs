using System.Threading.Tasks;
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
        private readonly ILogger<AuthorsController> _logger;
        private readonly IAuthorsRepository _repository;

        public AuthorsController(ILogger<AuthorsController> logger, IAuthorsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] AuthorsRequest request) => Ok();
    }
}
