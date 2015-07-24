using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KJ.Services
{
    /// <summary>
    /// MYProjects 的摘要说明 我发布的项目
    /// </summary>
    public class MYProjects : IHttpHandler
    {
        /// <summary>
        /// 我发布的项目
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
            Common.Logger.Info(string.Format("我发布的项目接口参数输出：userId：{0}，pageIndex：{1}，pageSize：{2}", userId, pageIndex, pageSize));

            // 处理登录请求
            string resultStatus = "0";
            string resultMessage = "";

            // 登录验证
            List<object> resultObjects = GetUserProjects(userId, pageIndex, pageSize, out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("我发布的项目接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 获取我的项目
        /// </summary>
        private List<object> GetUserProjects(string userId, string pageIndex, string pageSize, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "000";

            // 成功或错误消息
            resultMessage = "获取我的项目信息成功！";

            // 返回对象
            List<object> objs = new List<object>();

            // 
            int int_PageIndex = 0;
            int int_PageSize = 0;
            int int_UserId = 0;

            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out int_UserId) && !string.IsNullOrEmpty(pageIndex) && int.TryParse(pageIndex, out int_PageIndex) && !string.IsNullOrEmpty(pageSize) && int.TryParse(pageSize, out int_PageSize))
            {
                List<DataAccess.Models.kj_project> projects = Biz.UserBiz.Instance.GetUserProjects(int_UserId, int_PageIndex, int_PageSize);

                if (projects != null)
                {
                    foreach (var project in projects)
                    {
                        objs.Add(project);
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