namespace SimpleSur.Logger
{
    public interface ILogger
    {
        void LogDebug(string msg);
        
        void LogInfo(string msg);
        
        void LogWarn(string msg);
        
        void LogError(string msg);
        
        void Log(LogLevel logLevel, string msg);
    }
}

