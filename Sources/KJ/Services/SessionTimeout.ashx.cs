using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KJ.Services
{
    /// <summary>
    /// SessionTimeout 的摘要说明
    /// </summary>
    public class SessionTimeout : IHttpHandler
    {
        /// <summary>
        /// 当登录出错时，跳转到该接口中，并返回用户未登录，或登录超时提示
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Models.JsonObject obj = new Models.JsonObject
            {
                code = "099",
                msg = "用户未登录，或登录已过期，请重新登录！",
                data = new List<object>()
            };

            context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
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