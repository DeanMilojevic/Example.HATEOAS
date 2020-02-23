﻿using System.Threading.Tasks;
using Example.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Example.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(ILogger<AuthorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/authors")]
        public async Task<IActionResult> Get([FromQuery] AuthorsRequest request) => Ok();
    }
}