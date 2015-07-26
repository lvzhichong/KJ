using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace KJ.Services
{
    /// <summary>
    /// AddProjectRequire 的摘要说明 添加快竞项目要求
    /// </summary>
    public class AddProjectRequire : IHttpHandler
    {
        /// <summary>
        /// 处理添加项目请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            // 输出文档类型
            context.Response.ContentType = "text/plain";

            Dictionary<string, string> requestParams = Common.AppCode.GetRequestAllParams(context.Request);

            // 将参数日志输出
            Common.Logger.Info(string.Format("用户添加项目要求接口输入参数：{0}", string.Join("，", requestParams)));

            // 处理登录请求
            string resultStatus = "";
            string resultMessage = "";

            // 添加项目
            List<object> resultObjects = AddKJProjectRequire(requestParams, out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("用户添加项目要求接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 添加快竞项目要求
        /// </summary>
        private List<object> AddKJProjectRequire(Dictionary<string, string> requestParams, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "004";

            // 成功或错误消息
            resultMessage = "添加失败，请重试！";

            // 返回对象
            List<object> objs = new List<object>();

            // 参与主体、参与人数、所在区域、和发布方式不能为空
            int int_ProjectId = 0;
            string projectId = requestParams.Where(r => r.Key == "projectId").FirstOrDefault().Value;
            // 参与主体
            int int_JoinType = 0;
            string joinType = requestParams.Where(r => r.Key == "joinType").FirstOrDefault().Value;
            // 参与人数
            int int_JoinCount = 0;
            string joinCount = requestParams.Where(r => r.Key == "joinCount").FirstOrDefault().Value;
            // 所在区域
            int int_JoinArea = 0;
            string joinArea = requestParams.Where(r => r.Key == "joinArea").FirstOrDefault().Value;
            // 发布方式
            int int_PublicType = 0;
            string publicType = requestParams.Where(r => r.Key == "publicType").FirstOrDefault().Value;

            if (string.IsNullOrEmpty(projectId) || (!string.IsNullOrEmpty(projectId) && !int.TryParse(projectId, out int_ProjectId)))
            {
                resultStatus = "001";
                resultMessage = "项目信息不能为空或项目信息不正确！";
            }
            else if (string.IsNullOrEmpty(joinType))
            {
                resultStatus = "001";
                resultMessage = "参与主体不能为空！";
            }
            else if (!string.IsNullOrEmpty(joinType) && !int.TryParse(joinType, out int_JoinType))
            {
                resultStatus = "001";
                resultMessage = "参与主体参数不正确！";
            }
            else if (string.IsNullOrEmpty(joinCount))
            {
                resultStatus = "001";
                resultMessage = "参与人数不能为空！";
            }
            else if (!string.IsNullOrEmpty(joinCount) && !int.TryParse(joinCount, out int_JoinCount) && int_JoinCount < 100)
            {
                resultStatus = "001";
                resultMessage = "参与人数填写错误！";
            }
            else if (string.IsNullOrEmpty(joinArea))
            {
                resultStatus = "001";
                resultMessage = "区域不能为空！";
            }
            else if (!string.IsNullOrEmpty(joinArea) && !int.TryParse(joinArea, out int_JoinArea))
            {
                resultStatus = "001";
                resultMessage = "区域参数不正确！";
            }
            else if (string.IsNullOrEmpty(publicType))
            {
                resultStatus = "001";
                resultMessage = "发布类型不能为空！";
            }
            else if (!string.IsNullOrEmpty(publicType) && !int.TryParse(publicType, out int_PublicType))
            {
                resultStatus = "001";
                resultMessage = "发布类型参数不正确！";
            }
            else
            {
                // 资质要求
                string qualificationRequire = requestParams.Where(r => r.Key == "qualificationRequire").FirstOrDefault().Value;

                DataAccess.Models.kj_project project = new DataAccess.Models.kj_project
                {
                    project_id = int_ProjectId,
                    project_person = int_JoinCount,
                    project_publish = int_PublicType,
                    project_have = int_JoinType,
                    project_city = int_JoinArea,
                    project_aptitude = qualificationRequire
                };

                if (Biz.ProjectBiz.Instance.UpdateProject(project))
                {
                    resultStatus = "000";
                    resultMessage = "发布快竞项目成功！";
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