﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Sample.Repository.Interface;
using Sample.Repository.Models;

namespace Sample.Repository.Implement
{
    /// <summary>
    /// Blog Repository
    /// </summary>
    /// <seealso cref="Sample.Repository.Interface.IBologRepository" />
    /// <seealso cref="System.IDisposable" />
    public class BlogRepository : IBologRepository, IDisposable
    {
        private readonly BloggingEntities _db;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogRepository"/> class.
        /// </summary>
        public BlogRepository()
        {
            this._db = new BloggingEntities();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    this._db.Dispose();
                }

                // Note disposing has been done.
                this._disposed = true;
            }
        }

        /// <summary>
        /// 刪除 Blog
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception">Not fund blog</exception>
        public bool Remove(int id)
        {
            Blog blog = this._db.Blogs.Find(id);
            if (blog == null)
            {
                throw new Exception("Not fund blog");
            }

            this._db.Blogs.Remove(blog);
            var count = this._db.SaveChanges();

            return count > 0 ? true : false;
        }

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="predicate">查詢條件</param>
        /// <returns></returns>
        public IEnumerable<Blog> Get(Func<Blog, bool> predicate)
        {
            return this._db.Blogs.Where(predicate).AsEnumerable();
        }

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> GetAll()
        {
            return this._db.Blogs.AsEnumerable();
        }

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        public bool Update(Blog blog)
        {
            this._db.Entry(blog).State = EntityState.Modified;
            var count = this._db.SaveChanges();

            return count > 0 ? true : false;
        }

        /// <summary>
        /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        public bool Add(Blog blog)
        {
            this._db.Blogs.Add(blog);
            var count = this._db.SaveChanges();

            return count > 0 ? true : false;
        }
    }
}