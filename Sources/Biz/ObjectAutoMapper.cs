// Map
using AutoMapper;

namespace Biz.Map
{
    /// <summary>
    /// 对象映射配置
    /// </summary>
    public class ObjectAutoMapper
    {
        private static ObjectAutoMapper instance;

        /// <summary>
        /// ObjectAutoMapper 实例
        /// </summary>
        public static ObjectAutoMapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectAutoMapper();

                    return instance;
                }

                return instance;
            }
        }

        /// <summary>
        /// 配置对象之间的映射
        /// </summary>
        public void Configure()
        {
            // Definition
            // Mapper.CreateMap<DataAccess.Models.Definition, Models.Definition>();
            // Mapper.CreateMap<Models.Definition, DataAccess.Models.Definition>();
        }
    }
}