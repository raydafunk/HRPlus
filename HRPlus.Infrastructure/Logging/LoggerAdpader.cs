using HRPlus.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace HRPlus.Infrastructure.Logging
{
    public class LoggerAdpader<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdpader(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<T>();
        }
        public void LogInformation(string message, params object[] args)
        {
           _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
    }
}
