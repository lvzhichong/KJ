using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz
{
    /// <summary>
    /// 手机验证码业务管理
    /// </summary>
    public class PhoneVerifyCodeBiz
    {
        private static PhoneVerifyCodeBiz instance;

        /// <summary>
        /// PhoneVerifyCodeBiz 实例
        /// </summary>
        public static PhoneVerifyCodeBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhoneVerifyCodeBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 获取验证码，通过手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public kj_phone_verifycode GetPhoneVerifyCode(string phone)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    return context.kj_phone_verifycode.Where(p => p.phone_num == phone).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取验证码，通过手机号出错，Error：", ex);
            }

            return null;
        }

        /// <summary>
        /// 获取验证码，通过手机号
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public kj_phone_verifycode GetPhoneVerifyCode(string phone, string validCode)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    // 手机号和验证码都正确，且不过期的
                    return context.kj_phone_verifycode.Where(p => p.phone_num == phone && p.phone_code == validCode).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取验证码，通过手机号出错，Error：", ex);
            }

            return null;
        }

        /// <summary>
        /// 添加手机验证码
        /// </summary>
        /// <returns></returns>
        public bool AddPhoneVerifyCode(string phone, string verifyCode)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    kj_phone_verifycode code = new kj_phone_verifycode
                    {
                        phone_num = phone,
                        phone_state = 0,
                        phone_overdate = DateTime.Now.AddMinutes(15),
                        phone_code = verifyCode,
                        phone_createdate = DateTime.Now,
                    };

                    context.kj_phone_verifycode.Add(code);

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("添加kj_phone_verifycode出错，Error：", ex);
            }

            return false;
        }

        /// <summary>
        /// 更新 验证码超期时间
        /// </summary>
        /// <returns></returns>
        public bool UpdatePhoneVerifyCodeOverDate(string phone, string verifyCode)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    // 未启用的验证码
                    var phoneVerifycode = context.kj_phone_verifycode.Where(c => c.phone_num == phone && c.phone_code == verifyCode && c.phone_state == 0).FirstOrDefault();

                    context.kj_phone_verifycode.Attach(phoneVerifycode);

                    phoneVerifycode.phone_overdate = DateTime.Now;

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("修改kj_phone_verifycode出错，phone：" + phone + "，Error：", ex);
            }

            return false;
        }

        /// <summary>
        /// 验证验证码
        /// </summary>
        /// <param name="phoneId"></param>
        /// <returns></returns>
        public bool UpdatePhoneVerifyCodeState(int phoneId)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    var phoneVerifycode = context.kj_phone_verifycode.Where(c => c.phone_id == phoneId).FirstOrDefault();

                    context.kj_phone_verifycode.Attach(phoneVerifycode);

                    // 已验证过了
                    phoneVerifycode.phone_state = 2;

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("修改kj_phone_verifycode出错，phoneId：" + phoneId + "，Error：", ex);
            }

            return false;
        }
    }
}
