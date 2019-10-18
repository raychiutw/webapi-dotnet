using System;
using System.Linq;
using System.Linq.Expressions;
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
        /// <param name="predicate">查詢條件</param>
        /// <returns></returns>
        IQueryable<Blog> Get(Expression<Func<Blog, bool>> predicate);

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <returns></returns>
        IQueryable<Blog> GetAll();

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        void Update(Blog blog);

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        void Add(Blog blog);

        /// <summary>
        /// 刪除 Blog
        /// </summary>
        /// <param name="blog">Blog Id</param>
        void Remove(int id);
    }
}