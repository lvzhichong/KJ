using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KJ.Services
{
    /// <summary>
    /// Register 的摘要说明
    /// </summary>
    public class Register : IHttpHandler
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
            Common.Logger.Info(string.Format("用户注册接口参数输出：userName：{0}，userPassword：{1}，isOther：{2}", userName, userPassword, isOther));

            // 处理登录请求
            string resultStatus = "0";
            string resultMessage = "";

            // 注册用户
            List<object> resultObjects = RegisterUser(isOther, userName, userPassword, out resultStatus, out resultMessage);

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
            Common.Logger.Info(string.Format("用户注册接口处理结果：{0}", jsonResult));

            // 返回结果
            context.Response.Write(jsonResult);
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        private List<object> RegisterUser(string isOther, string userName, string userPassword, out string resultStatus, out string resultMessage)
        {
            // 处理状态
            resultStatus = "100";

            // 成功或错误消息
            resultMessage = "注册失败！";

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
            else if (string.IsNullOrEmpty(userPassword) && !isOtherBool)
            {
                resultStatus = "001";
                resultMessage = "用户密码不能为空！";
            }
            else
            {
                // 过滤特殊用户名
                string[] keyUserName = ConfigurationManager.AppSettings["regKeyUserName"].Split(',');

                if (keyUserName.Contains(userName.ToLower()))
                {
                    resultStatus = "005";
                    resultMessage = "该用户已注册，请更换用户名！";
                }
                else
                {
                    // 查找该用户名是否存在
                    DataAccess.Models.kj_user user = Biz.UserBiz.Instance.GetUserByName(userName);

                    if (user == null)
                    {
                        if (Common.AppCode.IsMobile(userName) || Common.AppCode.IsEmail(userName))
                        {
                            // 注册
                            int userId = Biz.UserBiz.Instance.AddUser(isOtherBool, userName, userPassword);

                            if (userId > 0)
                            {
                                // 添加enterprise
                                DataAccess.Models.kj_enterprise enterprise = new DataAccess.Models.kj_enterprise
                                {
                                    user_id = userId,
                                    category_id = 1,
                                    enterprise_area = 1,
                                };

                                if (Biz.EnterpriseBiz.Instance.AddEnterprise(enterprise))
                                {
                                    resultStatus = "000";
                                    resultMessage = "注册成功！";

                                    objs.Add(new DataAccess.Models.kj_user { user_id = userId, user_pwd = Common.MD5EncryptUtils.MD5Encrypt(userPassword) });
                                }
                                else
                                {
                                    // 清除之前插入到user表中的数据
                                    if (!Biz.UserBiz.Instance.DeleteUser(userId))
                                    {
                                        Common.Logger.Error(string.Format("注册用户时，添加Enterprise出错后，删除User时出错，产生异常数据：UserId={0}", userId));
                                    }
                                }
                            }
                        }
                        else
                        {
                            // 提示用户名格式不正确
                            resultStatus = "006";
                            resultMessage = "用户名格式不正确，请更换用户名！";
                        }
                    }
                    else
                    {
                        resultStatus = "005";
                        resultMessage = "该用户名已存在，请更换用户名！";

                        // 判断用户名是邮箱还是手机号
                        if (Common.AppCode.IsMobile(userName))
                        {
                            resultMessage = "该手机号已注册，请更换手机号，如果您忘了密码，请点击找回密码！";
                        }

                        if (Common.AppCode.IsEmail(userName))
                        {
                            resultMessage = "该邮箱已注册，请更换邮箱，如果您忘了密码，请点击找回密码！";
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