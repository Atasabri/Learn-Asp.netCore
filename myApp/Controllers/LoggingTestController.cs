using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Controllers
{
    public class LoggingTestController : Controller
    {
        private ILogger _logger;
        public LoggingTestController(ILogger<LoggingTestController> logger)
        {
            _logger = logger;
        }

        public string Test()
        {
            _logger.Log(LogLevel.Warning,"Test Log");
            _logger.LogTrace("Log Trace");
            _logger.LogError("Log Error");
            _logger.LogDebug("Log Debug");
            _logger.LogWarning("Log warning");
            _logger.LogCritical("Log Ciritical");
            _logger.LogInformation("Log Info");

            return "See OutPut Window or Cli Window";
        }
    }
}
