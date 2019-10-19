using System.Linq;
using Sample.Repository.Models;

namespace Sample.Repository.Interface
{
    /// <summary>
    /// Bolog Repository 介面
    /// </summary>
    public interface IBologRepository
    {
        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        Blog Get(int id);

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <returns></returns>
        IQueryable<Blog> GetAll();

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        bool Update(Blog blog);

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        bool Add(Blog blog);

        /// <summary>
        /// 刪除 Blog
        /// </summary>
        /// <param name="blog">Blog Id</param>
        bool Remove(int id);
    }
}