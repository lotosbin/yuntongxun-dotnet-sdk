using System;
using System.Configuration;

namespace com.cloopen.CCPRestSDK
{
    public class CCPRestClient : global::CCPRestSDK.CCPRestSDK
    {
        public CCPRestClient()
        {
            var restAddress = GetAppSetting("Yuntongxun_RestAddress");
            var restPort = GetAppSetting("Yuntongxun_RestPort");
            bool isInit = base.init(restAddress, restPort);
            var subAccountSid = GetAppSetting("Yuntongxun_SubAccountSid");
            var subAccountToken = GetAppSetting("Yuntongxun_SubAccountToken");
            var voipAccount = GetAppSetting("Yuntongxun_VoipAccount");
            var voipPassword = GetAppSetting("Yuntongxun_VoipPassword");
            base.setSubAccount(subAccountSid, subAccountToken, voipAccount, voipPassword);
            if (!isInit)
            {
                throw new Exception("≥ı ºªØ ß∞‹");
            }
        }

        private static string GetAppSetting(string settingName)
        {
            var s = ConfigurationManager.AppSettings[settingName];
            if (string.IsNullOrEmpty(s))
            {
                throw new ConfigurationErrorsException(settingName);
            }
            return s;
        }
    }
}