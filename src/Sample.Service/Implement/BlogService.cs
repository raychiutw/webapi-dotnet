using System;
using System.Collections.Generic;
using Sample.Common.Dto;
using Sample.Repository.Interface;
using Sample.Repository.Models;
using Sample.Service.Interface;

namespace Sample.Service.Implement
{
    /// <summary>
    /// Blog Service
    /// </summary>
    /// <seealso cref="Sample.Service.Interface.IBlogService" />
    public class BlogService : IBlogService
    {
        /// <summary>
        /// The blog repository
        /// </summary>
        private readonly IBologRepository _blogRepository;

        /// <summary>
        /// The log
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogService"/> class.
        /// </summary>
        /// <param name="bologRepository">The bolog repository.</param>
        public BlogService(
            IBologRepository bologRepository,
            ILog log)
        {
            this._blogRepository = bologRepository;
            this._log = log;
        }

        /// <summary>
        /// 刪除 Blog
        /// </summary>
        /// <param name="id"></param>
        public bool Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("參數錯誤");
            }

            var status = this._blogRepository.Remove(id);

            if (status)
            {
                this._log.Save($"Blog Id : {id} 已刪除");
            }

            return status;
        }

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        public BlogDto Get(int id)
        {
            var blog = this._blogRepository.Get(id); ;
            var dto = new BlogDto()
            {
                BlogId = blog.BlogId,
                Url = blog.Url
            };

            this._log.Save($"Blog Id : {id} 已取得");

            return dto;
        }

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <returns></returns>
        public List<BlogDto> GetAll()
        {
            var blogs = this._blogRepository.GetAll();

            var dtos = new List<BlogDto>();

            foreach (var blog in blogs)
            {
                var dto = new BlogDto()
                {
                    BlogId = blog.BlogId,
                    Url = blog.Url
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="dto">Blog Dto</param>
        public bool Update(BlogDto dto)
        {
            var blog = new Blog()
            {
                BlogId = dto.BlogId,
                Url = dto.Url
            };

            var status = this._blogRepository.Update(blog);

            if (status)
            {
                this._log.Save($"Blog Id : {blog.BlogId} 已更新");
            }

            return status;
        }

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="dto">Blog Dto</param>
        public bool Add(BlogDto dto)
        {
            var blog = new Blog()
            {
                BlogId = dto.BlogId,
                Url = dto.Url
            };

            var status = this._blogRepository.Add(blog);

            if (status)
            {
                this._log.Save($"Blog Id : {blog.BlogId} 已新增");
            }

            return status;
        }
    }
}