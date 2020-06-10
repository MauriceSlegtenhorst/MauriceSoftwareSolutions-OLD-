using System;
using System.IO;
using System.Threading.Tasks;

namespace SharedLibrary.Helpers
{
    public sealed class LogWriter
    {
        private string _logPath { get; }
        private StreamWriter _writer { get; }
        private StreamReader _reader { get; }

        public LogWriter(string logPath)
        {
            _logPath = logPath;

            SetupLogger();
        }

        /// <summary>
        /// Sets up the log writer and reader for use while the app is active
        /// </summary>
        private void SetupLogger()
        {
            //throw new NotImplementedException();
        }

        public async Task<bool> Log(string project, string message)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Log(string project, Exception ex)
        {
            throw new NotImplementedException();
        }
    }
}
