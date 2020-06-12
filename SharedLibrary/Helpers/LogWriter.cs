using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SharedLibrary.Helpers
{
    public sealed class LogWriter
    {
        private const string STANDARD_MESSAGE_LOG_WRITE_EXCEPTION = "Exception occured while writing to the log file:";
        private readonly string _logPath;

        public LogWriter(string logPath)
        {
            _logPath = logPath;
        }

        public async Task<bool> WriteLine(string project, string message)
        {
            if (!File.Exists(_logPath))
                File.CreateText(_logPath);

            try
            {
                using (StreamWriter streamWriter = new StreamWriter(_logPath))
                {
                    await streamWriter.WriteLineAsync($"[{DateTime.Now}] {project}: {message}");
                    streamWriter.Close();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{STANDARD_MESSAGE_LOG_WRITE_EXCEPTION} {ex.Message}\n{ex.InnerException.Message}");
                return false;
            }

            return true;
        }

        //public async Task<bool> wWriteLine(string project, Exception ex)
        //{

        //}
    }
}
