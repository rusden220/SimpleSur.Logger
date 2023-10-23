using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSur.Logger.LogWriters
{
    public class CompositeLogWriter: LogWriterBase
    {
        private readonly ILogger[] _loggers;

        public CompositeLogWriter(IEnumerable<ILogger> loggers): this(loggers?.ToArray())
        {
            
        }
        
        public CompositeLogWriter(params ILogger[] loggers)
        {
            if (loggers == null)
                throw new ArgumentNullException(nameof(loggers));

            _loggers = new ILogger[loggers.Length];
            
            for (int i = 0; i < _loggers.Length; i++)
            {
                if (loggers[i] == null)
                    throw new ArgumentNullException(nameof(loggers));
                
                _loggers[i] = loggers[i];
            }
        }
        
        protected override void LogMessage(LogLevel logLevel, string msg)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(logLevel, msg);
            }
        }
    }
}