using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biz
{
    /// <summary>
    /// ProjectBiz 业务操作
    /// </summary>
    public class ProjectBiz
    {
        private static ProjectBiz instance;

        /// <summary>
        /// ProjectBiz 实例
        /// </summary>
        public static ProjectBiz Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectBiz();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public int AddProject(DataAccess.Models.kj_project project)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    context.kj_project.Add(project);

                    if (context.SaveChanges() > 0)
                    {
                        return project.project_id;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("添加kj_project出错，Error：", ex);
            }

            return -1;
        }

        /// <summary>
        /// 更新快竞项目
        /// </summary>
        /// <returns></returns>
        public bool UpdateProject(DataAccess.Models.kj_project project)
        {
            try
            {
                using (kj_dataContext context = new kj_dataContext())
                {
                    var d_Project = context.kj_project.Where(p => p.project_id == project.project_id).FirstOrDefault();

                    context.kj_project.Attach(d_Project);

                    d_Project.project_id = project.project_id;
                    d_Project.project_person = project.project_id;
                    d_Project.project_publish = project.project_id;
                    d_Project.project_have = project.project_id;
                    d_Project.project_city = project.project_id;
                    d_Project.project_aptitude = project.project_aptitude;

                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("更新kj_project出错，Error：", ex);
            }

            return false;
        }

        /// <summary>
        /// 获取快竞项目
        /// </summary>
        /// <returns></returns>
        public List<DataAccess.Models.kj_project> GetProject(int categoryId, int categoryGroupId, int pageIndex, int pageSize)
        {
            try
            {
                using (DataAccess.Models.kj_dataContext context = new kj_dataContext())
                {
                    var projects = context.kj_project.Where(p => p.project_state == 0 && p.project_person > 0);

                    if (categoryId > 0)
                    {
                        projects = projects.Where(p => context.kj_category.Where(c => c.category_group_id == categoryGroupId).Any(c => c.category_id == p.category_id) || p.category_id == categoryId);
                    }
                    else
                    {
                        projects = projects.Where(p => context.kj_category.Where(c => c.category_group_id == categoryGroupId).Any(c => c.category_id == p.category_id));
                    }


                }
            }
            catch (Exception ex)
            {
                Common.Logger.Error("获取快竞项目出错，ERROR：", ex);
            }

            return null;
        }
    }
}
