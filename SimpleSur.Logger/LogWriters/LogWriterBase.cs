using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace SimpleSur.Logger.LogWriters
{
    public abstract class LogWriterBase: ILogger
    {
        private const string MessageTemplate = "{0}|{1}|{2}|{3}";
        
        private static readonly Dictionary<LogLevel, string> LogLevelToStringMapper = new Dictionary<LogLevel, string>()
        {
            { LogLevel.Debug, nameof(LogLevel.Debug) },
            { LogLevel.Info, nameof(LogLevel.Info) },
            { LogLevel.Warn, nameof(LogLevel.Warn) },
            { LogLevel.Error, nameof(LogLevel.Error) },
        };
        
        
        public virtual void LogDebug(string msg)
        {
            Log(LogLevel.Debug, msg);
        }

        public virtual void LogInfo(string msg)
        {
            Log(LogLevel.Info, msg);
        }

        public virtual void LogWarn(string msg)
        {
            Log(LogLevel.Warn, msg);
        }

        public virtual void LogError(string msg)
        {
            Log(LogLevel.Error, msg);
        }
        
        public virtual void Log(LogLevel logLevel, string msg)
        {            
            var msgInternal = GetMessageForWriting(logLevel, msg);
            LogInternal(logLevel, msgInternal);
        }

        private void LogInternal(LogLevel logLevel, string msg)
        {
            try
            {
                LogMessage(logLevel, msg);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        
        protected abstract void LogMessage(LogLevel logLevel, string msg);
        
        protected static string ConvertLogLevelToString(LogLevel logLevel)
        {
            return LogLevelToStringMapper[logLevel];
        }
        
        protected static string GetMessageForWriting(LogLevel logLevel, string message)
        {
            var utcDateTime = DateTime.UtcNow;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var stringLogLevel = ConvertLogLevelToString(logLevel);

            return string.Format(MessageTemplate, utcDateTime.ToString("O"), threadId, stringLogLevel, message);
        }
    }
}