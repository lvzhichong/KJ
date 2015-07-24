using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KJ.Services
{
    /// <summary>
    /// CheckValidCode 的摘要说明：验证码校验
    /// </summary>
    public class CheckValidCode : IHttpHandler
    {
        /// <summary>
        /// 处理登录请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            // 输出文档类型
            context.Response.ContentType = "text/plain";

            // 获取参数
            string mobilePhone = context.Request["mobilePhone"];
            string validCode = context.Request["validCode"];

            // 将参数日志输出
            Common.Logger.Info(string.Format("验证手机验证码接口参数输出：mobilePhone：{0}，validCode：{1}", mobilePhone, validCode));

            // 处理登录请求
            string resultStatus = "0";
            string resultMessage = "";

            // 手机号验证码验证发送
            List<object> resultObjects = ValidCode(mobilePhone, validCode, out resultStatus, out resultMessage);

            // 返回结果对象
            Models.JsonObject obj = new Models.JsonObject
            {
                code = resultStatus,
                msg = resultMessage,
                data = resultObjects
            };

            // 处理结果序列化
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

            // 记录返回结果信息
            Common.Logger.Info(string.Format("验证手机验证码接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 手机号验证码验证
        /// </summary>
        private List<object> ValidCode(string mobilePhone, string validCode, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "100";

            // 成功或错误消息
            resultMessage = "验证失败，请重试！";

            // 返回对象
            List<object> objs = new List<object>();

            if (string.IsNullOrEmpty(mobilePhone))
            {
                resultStatus = "001";

                resultMessage = "手机号不能为空！";
            }
            else if (string.IsNullOrEmpty(validCode))
            {
                resultStatus = "001";

                resultMessage = "验证码不能为空！";
            }
            else
            {
                var phoneVerifyCode = Biz.PhoneVerifyCodeBiz.Instance.GetPhoneVerifyCode(mobilePhone, validCode);

                if (phoneVerifyCode != null && Biz.PhoneVerifyCodeBiz.Instance.UpdatePhoneVerifyCodeState(phoneVerifyCode.phone_id))
                {
                    resultStatus = "000";

                    resultMessage = "验证通过！";
                }
            }

            return objs;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}