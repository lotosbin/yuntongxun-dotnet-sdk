﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace com.cloopen.CCPRestSDK {
    public class CCPRestSDKTyped {
        private readonly global::CCPRestSDK.CCPRestSDK _ccpRestSdk;

        public CCPRestSDKTyped(global::CCPRestSDK.CCPRestSDK ccpRestSdk) {
            _ccpRestSdk = ccpRestSdk;
        }

        public SendTemplateSMSResult SendTemplateSMS(string to, string templateId, string[] strings) {
            Dictionary<string, object> retData = _ccpRestSdk.SendTemplateSMS(to, templateId, strings);
            var result = JsonConvert.DeserializeObject<SendTemplateSMSResult>((string)retData["responseBody"]);
            return result;
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class SendTemplateSMSResult {
            public string statusCode { get; set; }
            public string statusMsg { get; set; }
        }
    }

}
