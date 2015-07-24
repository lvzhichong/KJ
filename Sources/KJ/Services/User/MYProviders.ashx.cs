using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KJ.Services
{
    /// <summary>
    /// MYProviders 的摘要说明
    /// </summary>
    public class MYProviders : IHttpHandler
    {
        /// <summary>
        /// 获取我的服务商接口
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            // 输出文档类型
            context.Response.ContentType = "text/plain";

            // 获取参数
            string userId = context.Request["userId"];
            string pageIndex = context.Request["pageIndex"];
            string pageSize = context.Request["pageSize"];

            // 将参数日志输出
            Common.Logger.Info(string.Format("获取我的服务商接口参数输出：userId：{0}，pageIndex：{1}，pageSize：{2}", userId, pageIndex, pageSize));

            // 处理登录请求
            string resultStatus = "0";
            string resultMessage = "";

            // 登录验证
            List<object> resultObjects = GetUserProviders(userId, context.User.Identity.Name, pageIndex, pageSize, out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("获取我的服务商接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 获取我的服务商
        /// </summary>
        private List<object> GetUserProviders(string userId, string userName, string pageIndex, string pageSize, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "000";

            // 成功或错误消息
            resultMessage = "获取我的服务商信息成功！";

            // 返回对象
            List<object> objs = new List<object>();

            // 
            int int_PageIndex = 0;
            int int_PageSize = 0;
            int int_UserId = 0;

            if (string.IsNullOrEmpty(userId))
            {
                // 处理状态
                resultStatus = "001";
                // 成功或错误消息
                resultMessage = "用户信息为空！";
            }
            else if (!string.IsNullOrEmpty(userId) && !int.TryParse(userId, out int_UserId))
            {
                // 处理状态
                resultStatus = "001";
                // 成功或错误消息
                resultMessage = "用户信息错误！";
            }
            if (string.IsNullOrEmpty(pageIndex))
            {
                // 处理状态
                resultStatus = "001";
                // 成功或错误消息
                resultMessage = "页码为空！";
            }
            else if (!string.IsNullOrEmpty(pageIndex) && !int.TryParse(pageIndex, out int_PageIndex))
            {
                // 处理状态
                resultStatus = "001";
                // 成功或错误消息
                resultMessage = "页码信息错误！";
            }
            if (string.IsNullOrEmpty(pageSize))
            {
                // 处理状态
                resultStatus = "001";
                // 成功或错误消息
                resultMessage = "页数为空！";
            }
            else if (!string.IsNullOrEmpty(pageSize) && !int.TryParse(pageSize, out int_PageSize))
            {
                // 处理状态
                resultStatus = "001";
                // 成功或错误消息
                resultMessage = "页数信息错误！";
            }
            else if (string.IsNullOrEmpty(userName))
            {
                // 处理状态
                resultStatus = "099";
                // 成功或错误消息
                resultMessage = "用户登录已失效，请重新登录！";
            }
            else
            {
                // 查看是否查的是自己的信息
                DataAccess.Models.kj_user user = Biz.UserBiz.Instance.GetUserByName(userName);

                if (user == null)
                {
                    // 处理状态
                    resultStatus = "001";
                    // 成功或错误消息
                    resultMessage = "用户信息错误！";
                }
                else if (user.user_id != int_UserId)
                {
                    // 处理状态
                    resultStatus = "001";
                    // 成功或错误消息
                    resultMessage = "用户信息错误！";
                }
                else
                {
                    List<DataAccess.Models.kj_service> providers = Biz.UserBiz.Instance.GetUserProviders(int_UserId, int_PageIndex, int_PageSize);

                    if (providers != null)
                    {
                        foreach (var provider in providers)
                        {
                            objs.Add(provider);
                        }
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