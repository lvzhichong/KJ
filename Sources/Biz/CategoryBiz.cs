using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz
{
    /// <summary>
    /// 行业分类管理
    /// </summary>
    public class CategoryBiz
    {
        private static CategoryBiz instance;

        /// <summary>
        /// CategoryBiz 实例
        /// </summary>
        public static CategoryBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 获取行业分类
        /// </summary>
        public List<kj_category_group> GetCategories()
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    List<kj_category_group> groups = new List<kj_category_group>();

                    foreach (kj_category_group categoryGroup in context.kj_category_group)
                    {
                        foreach (kj_category category in context.kj_category.Where(c => c.category_group_id == categoryGroup.category_group_id))
                        {
                            category.project_count = context.kj_project.Count(p => p.category_id == category.category_id);

                            if (categoryGroup.kj_categorys == null)
                            {
                                categoryGroup.kj_categorys = new List<kj_category>();
                            }

                            categoryGroup.kj_categorys.Add(category);
                        }

                        groups.Add(categoryGroup);
                    }

                    return groups;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取行业分类出错，Error：", ex);
            }

            return null;
        }
    }
}
