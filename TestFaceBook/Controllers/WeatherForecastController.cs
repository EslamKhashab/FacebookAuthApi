using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFaceBook.FacebookService;

namespace TestFaceBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFacebookAuthService _facebookAuthService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFacebookAuthService facebookAuthService)
        {
            _logger = logger;
            _facebookAuthService = facebookAuthService;
        }
        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(string accesstoken)
        {
            return Ok(await _facebookAuthService.GetUserInfoAsync(accesstoken));
        
        }
        [HttpGet("ValidateAccessToken")]
        public async Task<IActionResult> ValidateAccessToken(string accesstoken)
        {
            return Ok(await _facebookAuthService.ValidateAccessTokenAsync(accesstoken));

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
