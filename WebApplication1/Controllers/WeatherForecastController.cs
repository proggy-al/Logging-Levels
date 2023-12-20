using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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
        private readonly IHostApplicationLifetime _applicationLifetime;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHostApplicationLifetime applicationLifetime)
        {
            _logger = logger;
            _applicationLifetime = applicationLifetime;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("[action]")]
        public async Task<string> GetTest()
        {
            var test = "Test message";
            
            _logger.LogTrace("Trace");
            _logger.LogInformation("Information");
            _logger.LogError("Error");
            _logger.LogCritical("Critical");
            

            return test;
        }

        [HttpGet("stopApp")]
        public IActionResult StopApp()
        {
            _applicationLifetime.StopApplication();
            return new EmptyResult();
        }
    }
}