using System;
using CCPRestSDK;

namespace com.cloopen.CCPRestSDK {
    public class CCPRestClient : global::CCPRestSDK.CCPRestSDK {
        public CCPRestClient(CCPRestClientOptions options) {
            bool isInit = base.init(options.RestAddress, options.RestPort);
            base.setSubAccount(options.SubAccountSid, options.SubAccountToken, options.VoipAccount, options.VoipPassword);
            if (!isInit) {
                throw new Exception("≥ı ºªØ ß∞‹");
            }
        }
    }
}