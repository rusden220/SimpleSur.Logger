using System;
using System.Diagnostics;
using System.IO;
using System.Text;

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
                return;
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
                using var sw = new StreamWriter(path, true, Encoding.UTF8);
                sw.WriteLine(msg);
            }
        }
    }
}