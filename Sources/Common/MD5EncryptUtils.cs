using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public class MD5EncryptUtils
    {
        /// <summary>
        /// MD5加密 32位
        /// </summary>
        public static string MD5Encrypt(string value)
        {
            string pwd = "";

            MD5 md5 = MD5.Create();//实例化一个md5对像

            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("x").PadLeft(2, '0');
            }

            return pwd;
        }
    }
}
