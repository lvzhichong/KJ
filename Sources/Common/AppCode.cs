using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    /// <summary>
    /// 常用方法
    /// </summary>
    public class AppCode
    {
        /// <summary>
        /// 正则判断 是否是手机号
        /// ^[1]+[3,5,7,8]+\d{9}
        /// </summary>
        public static bool IsMobile(string value)
        {
            return Regex.IsMatch(value, @"^[1]+[3,5,7,8]+\d{9}");
        }

        /// <summary>
        /// 正则判断 是否是Email
        /// ^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$
        /// </summary>
        public static bool IsEmail(string value)
        {
            return Regex.IsMatch(value, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="Length"></param>
        /// <param name="Sleep"></param>
        /// <returns></returns>
        public static string Number(int Length, bool Sleep)
        {
            if (Sleep)
            {
                System.Threading.Thread.Sleep(3);
            }

            string result = "";

            System.Random random = new Random();

            for (int i = 0; i < Length; i++)
            {
                if (i == 0)
                {
                    result += random.Next(1, 10).ToString();
                }
                else
                {
                    result += random.Next(10).ToString();
                }
            }

            return result;
        }

        /// <summary>
        /// 给手机发送验证码
        /// </summary>
        /// <param name="mobilePhone"></param>
        /// <returns></returns>
        public static bool SendMobilePhoneValidCode(string mobilePhone, string validCode)
        {
            return SMSManager.SendSMS(mobilePhone, validCode);
        }

        /// <summary>
        /// 给邮箱发送验证码
        /// </summary>
        /// <param name="mobilePhone"></param>
        /// <returns></returns>
        public static bool SendEmailValidCode(string email)
        {
            bool result = false;



            return result;
        }

        /// <summary>
        /// 获取请求的所有参数
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetRequestAllParams(System.Web.HttpRequest request)
        {
            if (request != null)
            {
                // 请求参数
                Dictionary<string, string> requestParams = new Dictionary<string, string>();

                // Post
                foreach (string key in request.Form.Keys)
                {
                    requestParams.Add(key, request.Form[key]);
                }

                // Get
                foreach (string key in request.QueryString.Keys)
                {
                    requestParams.Add(key, request.QueryString[key]);
                }

                return requestParams;
            }

            return null;
        }
    }
}
