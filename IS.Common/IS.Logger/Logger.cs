using IS.Logger.Contractors;
using IS.Logger.Models;

namespace IS.Logger
{
    public class Logger : ILogger
    {
        private readonly string _filePath;
        public Logger(string filePath)
        {
            _filePath = filePath;

            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();
        }

        public async Task WriteInfoLog(string message)
        {
            string dateTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);

            await File.AppendAllTextAsync(_filePath,
                                          string.Concat(dateTime,
                                                        "     INFO     ",
                                                        message));
        }

        public async Task WriteWarnLog(string message)
        {
            string dateTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);

            await File.AppendAllTextAsync(_filePath,
                                          string.Concat(dateTime,
                                                        "     WARN     ",
                                                        message));
        }

        public async Task WriteErrorLog(string message, Exception exception)
        {
            string dateTime = DateTime.Now.ToString(Constants.LOG_DATE_TIME_FORMAT);

            await File.AppendAllTextAsync(_filePath,
                                          string.Concat(dateTime,
                                                        "     ERROR     ",
                                                        message,
                                                        Globals.NEWLINE,
                                                        exception.ToString()));
        }
    }
}