using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using EF.Diagnostics.Profiling;
using Sample.Repository.Infrastructure;
using Sample.Repository.Interface;
using Sample.Repository.Models;

namespace Sample.Repository.Implement
{
    /// <summary>
    /// Blog Repository
    /// </summary>
    /// <seealso cref="Sample.Repository.Interface.IBologRepository" />
    /// <seealso cref="System.IDisposable" />
    public class BlogRepositoryDapper : IBologRepository
    {
        private readonly IDatabaseConstants _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogRepository"/> class.
        /// </summary>
        public BlogRepositoryDapper(IDatabaseConstants databaseConstants)
        {
            this._database = databaseConstants;
        }

        /// <summary>
        /// 刪除 Blog
        /// </summary>
        /// <param name="id"></param>
        public bool Remove(int id)
        {
            var sql = "DELETE FROM Blog WHERE BlogId = @Id";

            using (var connection = this._database.GetConnection())
            {
                var count = connection.Execute(
                     sql,
                     new
                     {
                         Id = id
                     });

                return count > 0 ? true : false;
            }
        }

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="predicate">查詢條件</param>
        /// <returns></returns>
        public IEnumerable<Blog> Get(Func<Blog, bool> predicate)
        {
            var sql = @"SELECT BlogId, Url
                        FROM Blog WITH (NOLOCK)";

            using (var connection = this._database.GetConnection())
            {
                var blogs = connection.Query<Blog>(sql).Where(predicate);

                return blogs;
            }
        }

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> GetAll()
        {
            using (ProfilingSession.Current.Step($"{nameof(BlogRepositoryDapper)} - {nameof(GetAll)}"))
            {
                var sql = @"SELECT BlogId, Url
                        FROM Blog WITH (NOLOCK)";

                using (var connection = this._database.GetConnection())
                {
                    var blogs = connection.Query<Blog>(sql);

                    return blogs;
                }
            }
        }

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        public bool Update(Blog blog)
        {
            var sql = @"UPDATE Blog
                        SET Url = @Url
                        WHERE BlogId = @Id";

            using (var connection = this._database.GetConnection())
            {
                var count = connection.Execute(
                      sql,
                      new
                      {
                          Id = blog.BlogId,
                          Url = blog.Url
                      });

                return count > 0 ? true : false;
            }
        }

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="blog">Blog Entity</param>
        public bool Add(Blog blog)
        {
            var sql = @"INSERT INTO Blog
                        (BlogId, Url)
                        VALUES
                        (@Id, @Url)";

            using (var connection = this._database.GetConnection())
            {
                var count = connection.Execute(
                     sql,
                     new
                     {
                         Id = blog.BlogId,
                         Url = blog.Url
                     });

                return count > 0 ? true : false;
            }
        }
    }
}