using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz
{
    /// <summary>
    /// Enterprise 业务操作
    /// </summary>
    public class EnterpriseBiz
    {
        private static EnterpriseBiz instance;

        /// <summary>
        /// EnterpriseBiz 实例
        /// </summary>
        public static EnterpriseBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EnterpriseBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public bool AddEnterprise(DataAccess.Models.kj_enterprise enterprise)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    context.kj_enterprise.Add(enterprise);

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("添加kj_enterprise出错，Error：", ex);
            }

            return false;
        }
    }
}
