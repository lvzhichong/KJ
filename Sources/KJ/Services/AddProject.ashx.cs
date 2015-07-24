using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace KJ.Services
{
    /// <summary>
    /// AddProject 的摘要说明 添加快竞项目
    /// </summary>
    public class AddProject : IHttpHandler
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
            Common.Logger.Info(string.Format("用户添加项目接口输入参数：{0}", string.Join("，", requestParams)));

            // 处理登录请求
            string resultStatus = "";
            string resultMessage = "";

            // 添加项目
            List<object> resultObjects = AddKJProject(requestParams, out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("用户添加项目接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 添加快竞项目
        /// </summary>
        private List<object> AddKJProject(Dictionary<string, string> requestParams, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "004";

            // 成功或错误消息
            resultMessage = "添加失败，请重试！";

            // 返回对象
            List<object> objs = new List<object>();

            // 项目名称、手机号、验证码、所属行业和项目说明不能为空
            string name = requestParams.Where(r => r.Key == "name").FirstOrDefault().Value;
            string mobilePhone = requestParams.Where(r => r.Key == "mobilePhone").FirstOrDefault().Value;
            string validCode = requestParams.Where(r => r.Key == "validCode").FirstOrDefault().Value;

            int int_CategoryId = 0;
            string categoryId = requestParams.Where(r => r.Key == "categoryId").FirstOrDefault().Value;
            string description = requestParams.Where(r => r.Key == "description").FirstOrDefault().Value;

            // 价格
            decimal d_Money = 0;
            string money = requestParams.Where(r => r.Key == "money").FirstOrDefault().Value;

            // 用户Id
            int int_UserId = 0;
            string userId = requestParams.Where(r => r.Key == "userId").FirstOrDefault().Value;

            // 截至时间
            int int_ValidDate = 0;
            string validDate = requestParams.Where(r => r.Key == "validDate").FirstOrDefault().Value;

            if (string.IsNullOrEmpty(name))
            {
                resultStatus = "001";
                resultMessage = "项目名称不能为空！";
            }
            else if (string.IsNullOrEmpty(mobilePhone))
            {
                resultStatus = "001";
                resultMessage = "手机号不能为空！";
            }
            else if (string.IsNullOrEmpty(validCode))
            {
                resultStatus = "001";
                resultMessage = "验证码不能为空！";
            }
            else if (string.IsNullOrEmpty(categoryId) || (!string.IsNullOrEmpty(categoryId) && int.TryParse(categoryId, out int_CategoryId)))
            {
                resultStatus = "001";
                resultMessage = "所属行业不能为空或参数错误！";
            }
            else if (string.IsNullOrEmpty(description))
            {
                resultStatus = "001";
                resultMessage = "项目说明不能为空！";
            }
            else if (!string.IsNullOrEmpty(money) && !decimal.TryParse(money, out d_Money))
            {
                resultStatus = "001";
                resultMessage = "控制价格输入错误！";
            }
            else if (!string.IsNullOrEmpty(validDate) && !int.TryParse(validDate, out int_ValidDate))
            {
                resultStatus = "001";
                resultMessage = "有效时间输入错误！";
            }
            else if (!string.IsNullOrEmpty(userId) && !int.TryParse(userId, out int_UserId))
            {
                resultStatus = "001";
                resultMessage = "用户信息错误！";
            }
            else
            {
                // 手机验证码验证
                if (validCode != "123456")
                {
                    resultStatus = "007";
                    resultMessage = "手机验证码错误！";
                }
                else
                {
                    // 检查用户信息
                    if (string.IsNullOrEmpty(userId) && int_UserId <= 0)
                    {
                        // 查看该手机号是否已注册过
                        DataAccess.Models.kj_user user = Biz.UserBiz.Instance.GetUserByName(mobilePhone);

                        if (user == null)
                        {
                            // 如果不传入用户信息，则给该手机号创建一个用户，并返回
                            int_UserId = Biz.UserBiz.Instance.AddUser(false, mobilePhone, "123654");
                        }
                        else
                        {
                            int_UserId = user.user_id;
                        }
                    }

                    if (int_UserId <= 0)
                    {
                        // 创建用户出错
                        resultStatus = "006";
                        resultMessage = "用户信息错误！";
                    }
                    else
                    {
                        // 数据对象
                        DataAccess.Models.kj_project project = new DataAccess.Models.kj_project
                        {
                            user_id = int_UserId,
                            project_name = name,
                            project_phone = mobilePhone,
                            category_id = int_CategoryId,
                            project_money = d_Money,
                            project_intro = description,

                            project_pubdate = DateTime.Now,
                            project_time = DateTime.Now.AddDays(int_ValidDate),
                            project_hours = int_ValidDate,
                            project_bid_date = DateTime.Now
                        };

                        // 添加快竞项目
                        int projectId = Biz.ProjectBiz.Instance.AddProject(project);

                        if (projectId > 0)
                        {
                            resultStatus = "000";
                            resultMessage = "添加快竞项目成功！";

                            objs.Add(new DataAccess.Models.kj_project { project_id = projectId, user_id = int_UserId });
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