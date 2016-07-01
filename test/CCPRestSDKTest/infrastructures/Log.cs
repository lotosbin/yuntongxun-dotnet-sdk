using CCPRestSDK;
using Xunit.Abstractions;

namespace CCPRestSDKTest
{
    public class Log : ILog {
        private readonly ITestOutputHelper _outputter;

        public Log(ITestOutputHelper outputter) {
            _outputter = outputter;
        }

        public void Error(string message) {
            _outputter.WriteLine(message);
        }
    }
}