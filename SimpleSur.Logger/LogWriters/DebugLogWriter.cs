using System.Diagnostics;

namespace SimpleSur.Logger.LogWriters
{
    public class DebugLogWriter: LogWriterBase
    {
        protected override void LogMessage(LogLevel logLevel, string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}