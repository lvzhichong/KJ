using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KJ.Models
{
    /// <summary>
    /// 接口返回对象类
    /// </summary>
    public class JsonObject
    {
        /// <summary>
        /// 模块名字（服务器端使用）
        /// </summary>
        // public string modelName { get; set; }

        /// <summary>
        /// 执行状态，成功为：000，失败为：001或者其他
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 处理消息，成功为：成功！，失败为：错误信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据结果数量
        /// </summary>
        // public string count { get; set; }

        /// <summary>
        /// 执行操作返回时间（即当前时间）
        /// </summary>
        // public string currentTime { get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); } }

        /// <summary>
        /// 接口返回结果集
        /// </summary>
        public List<object> data { get; set; }
    }
}