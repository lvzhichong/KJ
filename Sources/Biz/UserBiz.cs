using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz
{
    /// <summary>
    /// 用户操作
    /// </summary>
    public class UserBiz
    {
        private static UserBiz instance;

        /// <summary>
        /// UserBiz 实例
        /// </summary>
        public static UserBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 通过用户获取用户
        /// </summary>
        public kj_user GetUserByName(string userName)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    return context.kj_user.Where(u => u.user_name == userName).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("通过用户名，获取用户出错，Error：", ex);
            }

            return null;
        }

        /// <summary>
        /// 通过用户名和密码获取用户
        /// </summary>
        public kj_user GetUserByNameAndPassword(string userName, string userPassword)
        {
            try
            {
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userPassword))
                {
                    // 密码加密处理（该处理需要手机端给出）
                    userPassword = Common.MD5EncryptUtils.MD5Encrypt(userPassword);

                    using (kj_dataContext context = new kj_dataContext())
                    {
                        return context.kj_user.Where(u => u.user_name == userName && u.user_pwd == userPassword).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("通过用户名，获取用户出错，Error：", ex);
            }

            return null;
        }

        /// <summary>
        /// 更新用户登录时间
        /// </summary>
        public bool UpdateUserLoginDate(string userName)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    kj_user user = context.kj_user.Where(u => u.user_name == userName).FirstOrDefault();

                    if (user != null)
                    {
                        context.kj_user.Attach(user);

                        user.user_lastlogindate = DateTime.Now;

                        return context.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("更新用户登录时间出错，Error：", ex);
            }

            return false;
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        public kj_user VaildateUser(bool isOther, string userName, string userPassword)
        {
            kj_user user;

            // 如果是第三方用户登录，只需要使用用户名即可
            if (isOther)
            {
                user = GetUserByName(userName);
            }
            else
            {
                user = GetUserByNameAndPassword(userName, userPassword);
            }

            if (user != null)
            {
                // 更新登录时间
                UpdateUserLoginDate(user.user_name);
            }

            return user;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        public int AddUser(bool isOther, string userName, string userPassword)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    kj_user user = new kj_user
                    {
                        user_name = userName,
                        user_pwd = Common.MD5EncryptUtils.MD5Encrypt(userPassword),
                        user_regdate = DateTime.Now,
                        user_lastlogindate = DateTime.Now,
                        user_attr = 0
                    };

                    context.kj_user.Add(user);

                    if (context.SaveChanges() > 0)
                    {
                        return user.user_id;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("添加kj_user出错，Error：", ex);
            }

            return -1;
        }

        /// <summary>
        /// 通过用户名删除用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DeleteUser(string userName)
        {
            bool result = false;

            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    context.kj_user.Remove(context.kj_user.Where(u => u.user_name == userName).FirstOrDefault());

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("删除kj_user出错，Error：", ex);
            }

            return result;
        }

        /// <summary>
        /// 通过用户Id删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(int userId)
        {
            bool result = false;

            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    context.kj_user.Remove(context.kj_user.Where(u => u.user_id == userId).FirstOrDefault());

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("删除kj_user出错，Error：", ex);
            }

            return result;
        }

        /// <summary>
        /// 获取用户服务商信息
        /// </summary>
        public List<kj_service> GetUserProviders(int userId, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    var services = context.kj_service.Where(s => s.user_id == userId).OrderByDescending(s => s.service_id).Skip((pageIndex - 1) * pageSize).Take(pageSize);

                    foreach (kj_service service in services)
                    {
                        // 获取主营业务
                        var enterprise = context.kj_enterprise.Where(e => e.enterprise_id == service.enterpries_id).FirstOrDefault();

                        service.enterprise_primary = string.Join(" / ", context.kj_category.Where(c => c.category_id == enterprise.enterprise_primary1 || c.category_id == enterprise.enterprise_primary2 || c.category_id == enterprise.enterprise_primary3).Select(c => c.category_name));
                    }

                    return services.ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("通过用户Id，获取用户服务商，Error：", ex);
            }

            return null;
        }

        /// <summary>
        /// 获取我发布的项目
        /// </summary>
        public List<kj_project> GetUserProjects(int userId, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    return context.kj_project.Where(s => s.user_id == userId).OrderByDescending(s => s.project_id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("通过用户Id，获取用户发布的项目，Error：", ex);
            }

            return null;
        }

        /// <summary>
        /// 获取我抢竟的项目
        /// </summary>
        public List<kj_project_bid_enterprise> GetUserBidProjects(int userId, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    return context.kj_project_bid_enterprise.Where(s => s.user_id == userId).OrderByDescending(s => s.project_id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("通过用户Id，获取用户抢竟的项目，Error：", ex);
            }

            return null;
        }
    }
}
