using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using com.cloopen.CCPRestSDK;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace CCPRestSDKTest {
    public class CCPRestSDKTypedTests {
        private readonly ITestOutputHelper _outputter;

        public CCPRestSDKTypedTests(ITestOutputHelper output) {
            _outputter = output;
        }
        [Fact]
        public void SendTemplateSMSTest() {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var accountSid = config["cloopen:AccountId"];
            var accountToken = config["cloopen:AuthToken"];
            var appId = config["cloopen:AppId"];

            string ret = null;

            var api = new CCPRestSDK.CCPRestSDK {
                Log = new Log(_outputter)
            };
            bool isInit = api.init("sandboxapp.cloopen.com", "8883");
            api.setAccount(accountSid, accountToken);
            api.setAppId(appId);
            var result = api.AsTyped().SendTemplateSMS("18121629620", "59680", new string[] { "1234", "5" });
            Assert.Equal(true, isInit);
            Assert.Equal("00000", result.statusCode);
        }

        [Fact]
        public void test() {
            var dictionary = Dictionary();
            Assert.True(dictionary.ContainsKey("resposeBody"));
            Assert.True(dictionary.Keys.Contains("resposeBody"));
        }

        private static Dictionary<string, string> Dictionary() {
            var dictionary = new Dictionary<string, string>();
            dictionary.Clear();
            dictionary["resposeBody"] = "s";
            return dictionary;
        }
    }
}
