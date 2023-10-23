using System;

namespace SimpleSur.Logger
{
    public static class LogHelper
    {
        public static void LogEnvironmentInfo(ILogger logger)
        {
            var info = GetEnvironmentInfo();
            logger.LogInfo(info);
        }
        
        public static string GetEnvironmentInfo()
        {
            var os = Environment.OSVersion;
            var timeOffset = DateTimeOffset.Now.Offset;
            var dotNetVersion = Environment.Version;
            var result = $"Os: {os}; TimeOffset: {timeOffset}; dotNetVersion: {dotNetVersion}";
            
            return result;
        }
    }
}