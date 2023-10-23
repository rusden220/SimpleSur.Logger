using System;

namespace SimpleSur.Logger
{
    public class LogHelper
    {
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