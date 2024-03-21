using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
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
        /// <summary>
        /// Базовый метод контроллера прогноза погоды
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Генерация записи в лог тестовых сообщений 3244241242134234
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]", Name ="Show Logger Ability")]
        public async Task<string> GetTest()
        {
            var test = "Test message";
            
            _logger.LogTrace("Trace log mes");
            _logger.LogInformation("Information log mes");
            _logger.LogWarning("Warning log mes");
            _logger.LogError("Error log mes");
            _logger.LogCritical("Critical log mes");
            

            return test;
        }

        /// <summary>
        /// Остановка приложения
        /// </summary>
        /// <returns>Ничего не возвращает</returns>
        [HttpGet("stopApp", Name ="Stop Application")]
        public IActionResult StopApp()
        {
            _applicationLifetime.StopApplication();
            return new EmptyResult();
        }
    }
}