using Heroes_Api.Contracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Services
{
    public class LoggerService:ILoggerService
    {
        private ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string massage)
        {
            logger.Debug(massage);
        }

        public void LogError(string massage)
        {
            logger.Error(massage);
        }

        public void LogInfo(string massage)
        {
            logger.Info(massage);
        }

        public void LogWarn(string massage)
        {
            logger.Warn(massage);
        }
    }
}
