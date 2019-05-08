using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace worthWatchingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        public HealthCheckController(IConfiguration configuration)
        {
            // non-functional dependencies
            _configuration = configuration;           
        }

        /// <summary>
        /// Indicates if application is running and responsive.
        /// Responds with HTTP 200 if request is successfully routed to application. 
        /// Can be used to monitor application is running and responsive.
        /// </summary>
        [HttpGet("isAlive")]
        public IActionResult IsAlive()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var testvar = Environment.GetEnvironmentVariable("testvar");
            var valueFromConfigFile = _configuration.GetSection("SettingsTestValue").Get<string>();
            return Ok($"I am Alive!!{ Environment.NewLine}" +
                $"ASPNETCORE_ENVIRONMENT variable = { env + Environment.NewLine}" +
                $"Settings Value = {valueFromConfigFile + Environment.NewLine}" +
                $"Publish Profile = {testvar + Environment.NewLine}");
        }
    }
}