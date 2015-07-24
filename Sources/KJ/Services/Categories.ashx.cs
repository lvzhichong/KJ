using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KJ.Services
{
    /// <summary>
    /// Categories 的摘要说明 行业类别
    /// </summary>
    public class Categories : IHttpHandler
    {
        /// <summary>
        /// 行业类别接口
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            // 处理登录请求
            string resultStatus = "0";
            string resultMessage = "";

            // 注册用户
            List<object> resultObjects = GetCategories(out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("行业类别接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 获取行业类别
        /// </summary>
        /// <returns></returns>
        private List<object> GetCategories(out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "000";

            // 成功或错误消息
            resultMessage = "获取行业类别！";

            // 返回对象
            List<object> objs = new List<object>();

            List<DataAccess.Models.kj_category_group> categories = Biz.CategoryBiz.Instance.GetCategories();

            if (categories != null)
            {
                foreach (var category in categories)
                {
                    objs.Add(category);
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