using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Contracts
{
    public interface ILoggerService
    {
        void LogInfo(string massage);
        void LogWarn(string massage);
        void LogDebug(string massage);
        void LogError(string massage);
    }
}
