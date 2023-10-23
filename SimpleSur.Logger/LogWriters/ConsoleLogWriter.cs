using System;

namespace SimpleSur.Logger.LogWriters
{
    public class ConsoleLogWriter: LogWriterBase
    {
        protected override void LogMessage(LogLevel logLevel, string msg)
        {
            Console.WriteLine(msg);
        }
    }
}