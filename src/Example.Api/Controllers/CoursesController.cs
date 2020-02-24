using Example.Api.Models;
using Example.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example.Api.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly ICoursesRepository _repository;

        public CoursesController(ILogger<CoursesController> logger, ICoursesRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CoursesRequest request) => Ok();
    }
}
