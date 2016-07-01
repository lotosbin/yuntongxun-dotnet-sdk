using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.cloopen.CCPRestSDK {
    public static class CCPRestSDKTypedExtension {
        public static CCPRestSDKTyped AsTyped(this global::CCPRestSDK.CCPRestSDK sdk) {
            return new CCPRestSDKTyped(sdk);
        }
    }
}
