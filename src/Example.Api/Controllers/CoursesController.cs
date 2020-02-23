using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example.Api.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ILogger<CoursesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok();
    }
}
