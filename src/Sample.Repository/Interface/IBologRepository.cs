using System;
using System.Collections.Generic;
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
        IEnumerable<Blog> Get(Func<Blog, bool> predicate);

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <returns></returns>
        IEnumerable<Blog> GetAll();

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