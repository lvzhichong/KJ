using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KJ.Services
{
    /// <summary>
    /// GetMobileValidCode 的摘要说明：获取手机验证码
    /// </summary>
    public class GetMobileValidCode : IHttpHandler
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

            // 将参数日志输出
            Common.Logger.Info(string.Format("用户获取手机验证码接口参数输出：mobilePhone：{0}", mobilePhone));

            // 处理登录请求
            string resultStatus = "0";
            string resultMessage = "";

            // 手机号验证码验证发送
            List<object> resultObjects = SendMobilePhoneValidCode(mobilePhone, out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("用户获取手机验证码接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 手机号验证码验证
        /// </summary>
        private List<object> SendMobilePhoneValidCode(string mobilePhone, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "100";

            // 成功或错误消息
            resultMessage = "发送失败，请重试！";

            // 返回对象
            List<object> objs = new List<object>();

            if (string.IsNullOrEmpty(mobilePhone))
            {
                // 手机号为空
                resultStatus = "001";
                resultMessage = "手机号不能为空！";
            }
            else if (!Common.AppCode.IsMobile(mobilePhone))
            {
                // 手机号格式不对
                resultStatus = "003";
                resultMessage = "手机号格式错误！";
            }
            else
            {
                // 验证码
                string validCode = Common.AppCode.Number(4, true);

                DataAccess.Models.kj_phone_verifycode phoneVerifyCode = Biz.PhoneVerifyCodeBiz.Instance.GetPhoneVerifyCode(mobilePhone);

                if (phoneVerifyCode != null && phoneVerifyCode.phone_state == 0)
                {
                    validCode = phoneVerifyCode.phone_code;

                    // 发送验证码，并更新验证时间
                    if (Common.AppCode.SendMobilePhoneValidCode(mobilePhone, validCode))
                    {
                        // 更新验证时间
                        Biz.PhoneVerifyCodeBiz.Instance.UpdatePhoneVerifyCodeOverDate(mobilePhone, validCode);
                    }
                }
                else
                {
                    // 发送验证码
                    if (Common.AppCode.SendMobilePhoneValidCode(mobilePhone, validCode))
                    {
                        resultStatus = "000";
                        resultMessage = "验证码发生成功！";

                        // 存入数据库中
                        Biz.PhoneVerifyCodeBiz.Instance.AddPhoneVerifyCode(mobilePhone, validCode);
                    }
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