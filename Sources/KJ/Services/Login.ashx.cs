using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace KJ.Services
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
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
            string userName = context.Request["userName"];
            string userPassword = context.Request["userPassword"];
            string isOther = context.Request["isOther"];

            // 将参数日志输出
            Common.Logger.Info(string.Format("用户登录接口输入参数：{0}", string.Join("，", Common.AppCode.GetRequestAllParams(context.Request))));

            // 处理登录请求
            string resultStatus = "";
            string resultMessage = "";

            // 登录验证
            List<object> resultObjects = VaildateUser(isOther, userName, userPassword, out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("用户登录接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        private List<object> VaildateUser(string isOther, string userName, string userPassword, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "004";

            // 成功或错误消息
            resultMessage = "登录失败，用户名或密码错误！";

            // 返回对象
            List<object> objs = new List<object>();

            bool isOtherBool = false;

            if (!string.IsNullOrEmpty(isOther) && isOther == "1")
            {
                isOtherBool = true;
            }

            if (string.IsNullOrEmpty(userName))
            {
                resultStatus = "001";
                resultMessage = "用户名不能为空！";
            }
            else if (string.IsNullOrEmpty(userPassword))
            {
                resultStatus = "001";
                resultMessage = "密码不能为空！";
            }
            else
            {
                DataAccess.Models.kj_user user = Biz.UserBiz.Instance.VaildateUser(isOtherBool, userName, userPassword);

                if (user != null)
                {
                    resultStatus = "000";
                    resultMessage = "登录成功！";

                    objs.Add(user);

                    // 服务器授权
                    FormsAuthentication.SetAuthCookie(userName, true);
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