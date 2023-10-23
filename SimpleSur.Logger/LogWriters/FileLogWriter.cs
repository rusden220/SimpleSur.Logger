using System;
using System.Diagnostics;
using System.IO;

namespace SimpleSur.Logger.LogWriters
{
    public class FileLogWriter: LogWriterBase
    {
        private readonly string _path;
        private readonly object _lockObject = new object();

        public FileLogWriter(string path)
        {
            _path = path;
        }
        
        protected override void LogMessage(LogLevel logLevel, string msg)
        {
            try
            {
                LogToFile(msg, _path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            var newPath = _path + Guid.NewGuid();
            LogToFile(msg, newPath);
        }
        
        private void LogToFile(string msg, string path)
        {
            lock (_lockObject)
            {
                using var sw = new StreamWriter(path);
                sw.WriteLine(msg);
            }
        }
    }
}