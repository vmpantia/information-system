using IS.Logger.Contractors;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;

namespace IS.Logger.Test
{
    public class LoggerTest
    {
        private ILogger _logger;
        private string _filePath = @"C:\Users\vince\source\repos\vmpantia\InformationSystem\IS.Common\IS.Logger.Test\bin\Test\TestLog.log";

        [SetUp]
        public void Setup()
        {
           
            _logger = new Logger(_filePath);
        }

        [Test]
        public void WriteInfoLogTest_001()
        {
            string message = "-- WriteInfoLog --";

            _logger.WriteInfoLog(message);

            Assert.AreEqual(true, IsLastLogMatch(message));
        }
        [Test]
        public void WriteInfoLogTest_002()
        {
            string message = string.Empty;

            _logger.WriteInfoLog(message);

            Assert.AreEqual(true, IsLastLogMatch(message));
        }
        [Test]
        public void WriteInfoLogTest_003()
        {
            string message = null;

            _logger.WriteInfoLog(message);

            Assert.AreEqual(true, IsLastLogMatch(message));
        }
        [Test]
        public void WriteWarnLogTest_004()
        {
            string message = "-- WriteWarnLog --";

            _logger.WriteWarnLog(message);

            Assert.AreEqual(true, IsLastLogMatch(message));
        }
        [Test]
        public void WriteWarnLogTest_005()
        {
            string message = string.Empty;

            _logger.WriteWarnLog(message);

            Assert.AreEqual(true, IsLastLogMatch(message));
        }
        [Test]
        public void WriteWarnLogTest_006()
        {
            string message = null;

            _logger.WriteWarnLog(message);

            Assert.AreEqual(true, IsLastLogMatch(message));
        }

        public bool IsLastLogMatch(string message, Exception ex = null)
        {
            string lastLog = File.ReadLines(_filePath).Last();

            return lastLog.Contains(message);
        }
    }
}