using System;
using System.Collections.Generic;

namespace CCPRestSDK.NetCore.Console.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");



            string ret = null;

            CCPRestSDK api = new CCPRestSDK();

            bool isInit = api.init("sandboxapp.cloopen.com", "8883");
            api.setAccount(主帐号, 主帐号令牌);
            api.setAppId(应用ID);

            try
            {
                if (isInit)
                {
                    Dictionary<string, object> retData = api.SendTemplateSMS(短信接收号码, 短信模板id, 内容数据);
                    ret = getDictionaryData(retData);
                }
                else
                {
                    ret = "初始化失败";
                }
            }
            catch (Exception exc)
            {
                ret = exc.Message;
            }
            finally
            {
                //Response.Write(ret);
            }
        }


        private static string getDictionaryData(Dictionary<string, object> data)
        {
            string ret = null;
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value != null && item.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    ret += item.Key.ToString() + "={";
                    ret += getDictionaryData((Dictionary<string, object>)item.Value);
                    ret += "};";
                }
                else
                {
                    ret += item.Key.ToString() + "=" + (item.Value == null ? "null" : item.Value.ToString()) + ";";
                }
            }
            return ret;
        }
    }
}
