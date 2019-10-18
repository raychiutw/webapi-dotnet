using System.Collections.Generic;
using Sample.Common.Dto;

namespace Sample.Service.Interface
{
    /// <summary>
    /// Blog Service 介面
    /// </summary>
    public interface IBlogService
    {
        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        List<BlogDto> Get(int id);

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="dto">Blog Dto</param>
        void Update(BlogDto dto);

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="dto">Blog Dto</param>
        void Add(BlogDto dto);

        /// <summary>
        /// 刪除 Blog
        /// </summary>
        /// <param name="dto">Blog Dto</param>
        void Remove(int id);
    }
}