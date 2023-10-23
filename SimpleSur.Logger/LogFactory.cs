using System.Collections.Generic;
using SimpleSur.Logger.LogWriters;

namespace SimpleSur.Logger
{
    public static class LoggerFactory
    {
        public static ILogger Create()
        {
            var defaultLogger = GetDefaultLoggers();
            var result = new CompositeLogWriter(defaultLogger);
            
            return result;
        }
    
        public static ILogger Create(string path)
        {
            var defaultLogger = GetDefaultLoggers();
            defaultLogger.Add(new FileLogWriter(path));
            var result = new CompositeLogWriter(defaultLogger);

            return result;
        }

        private static List<ILogger> GetDefaultLoggers()
        {
            var result = new List<ILogger>
            {
                new DebugLogWriter(),
                new ConsoleLogWriter()
            };

            return result;
        }
    }
}

