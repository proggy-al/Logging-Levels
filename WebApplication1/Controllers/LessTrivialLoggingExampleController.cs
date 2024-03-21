using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Infrastructrure;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class LessTrivialLoggingExampleController: ControllerBase
    {
        private readonly ILogger<LessTrivialLoggingExampleController> _logger;

        public LessTrivialLoggingExampleController(ILogger<LessTrivialLoggingExampleController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Менее тривиальный пример логирования
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]", Name = "Hello world")]
        public string GetTest2()
        {
            LogHandleRequest(_logger);
            return "Hello World";
        }

        [LoggerMessage(EventId = 1000, Level = LogLevel.Warning, Message = "ExampleHandler.HandleRequest was called")]
        public static partial void LogHandleRequest(ILogger logger);
    }
}
