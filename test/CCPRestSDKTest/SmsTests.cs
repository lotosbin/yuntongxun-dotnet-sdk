using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;
using Xunit.Abstractions;

namespace CCPRestSDKTest {
    public class SmsTests {
        private readonly ITestOutputHelper _outputter;

        public SmsTests(ITestOutputHelper output) {
            _outputter = output;
        }
        //　发送短信需要收费
        //[Fact]
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
            Assert.Equal(true, isInit);
            Dictionary<string, object> retData = api.SendTemplateSMS("18121629620", "59680", new string[] { "1234", "5" });
            ret = getDictionaryData(retData);
            Assert.NotNull(retData);
            Assert.NotEmpty(retData);
            Assert.Equal("00000", retData["statusCode"]);
        }
        private string getDictionaryData(Dictionary<string, object> data) {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data) {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>)) {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
    }
}
