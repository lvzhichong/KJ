using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 短信发送管理
    /// </summary>
    public class SMSManager
    {


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobilePhone">手机号</param>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public static bool SendSMS(string mobilePhone, string code)
        {
            CCPRestSDK.CCPRestSDK api = new CCPRestSDK.CCPRestSDK();

            //ip格式如下，不带https://
            bool isInit = api.init("sandboxapp.cloopen.com", "8883");
            api.setAccount("8a48b5514df54891014df63280700163", "4fd7fabe5fd84ada83203b5a8c444cfa");
            api.setAppId("aaf98f894df52772014df632ab7d01af");

            try
            {
                if (isInit)
                {
                    Dictionary<string, object> retData = api.SendTemplateSMS(mobilePhone, "1", new string[] { code, "15" });

                    if (retData != null)
                    {
                        var statusCode = retData.Where(r => r.Key == "statusCode").FirstOrDefault().Value.ToString();

                        // 记录短信调用返回值
                        Common.Logger.Info(getDictionaryData(retData));

                        if (statusCode == "000000")
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    Common.Logger.Warn("发送短信初始化失败！");
                }
            }
            catch (Exception exc)
            {
                Common.Logger.Warn("发送短信出错，ERROR：" + exc);
            }

            return false;
        }

        /// <summary>
        /// 解析发送SMS返回数据包
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
