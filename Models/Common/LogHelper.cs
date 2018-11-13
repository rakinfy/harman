using System;
using System.Threading;
using log4net;

namespace Patient_API.Models.Common
{
    public static class LogHelper
    {
        private static ILog _logger;
        private static ILog _infoLogger;

        static LogHelper()
        {
            _logger = LogManager.GetLogger("GenericLoging");
            _infoLogger = LogManager.GetLogger("InfoLoging");
        }

        public static void Info(string info)
        {
            Info(info, false);
        }

        public static void Info(string info, bool isInfoLogger)
        {
            if (isInfoLogger)
                _infoLogger.Info(info);
            else
                _logger.Info(info);
        }


        public static void Warn(string message, Exception ex)
        {
            _logger.Warn(message, ex);
        }

        public static void Warn(string message)
        {
            _logger.Warn(message);
        }

        public static void Error(string message, Exception ex)
        {
            if (ex is ThreadAbortException)
            {
                // no loggin of ThreadAbortException
            }
            else
                _logger.Error(message, ex);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }
    }
}
