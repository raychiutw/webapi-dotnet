﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogService"/> class.
        /// </summary>
        /// <param name="bologRepository">The bolog repository.</param>
        public BlogService(
            IBologRepository bologRepository,
            IMapper mapper)
        {
            this._blogRepository = bologRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 刪除 Blog
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            this._blogRepository.Remove(id);
        }

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        public BlogDto Get(int id)
        {
            var blog = this._blogRepository.Get(x => x.BlogId == id)
                                            .FirstOrDefault();

            var dto = this._mapper.Map<BlogDto>(blog);

            return dto;
        }

        /// <summary>
        /// 取得所有 Blog
        /// </summary>
        /// <returns></returns>
        public List<BlogDto> GetAll()
        {
            var blogs = this._blogRepository.GetAll();

            var dtos = this._mapper.Map<List<BlogDto>>(blogs);

            return dtos;
        }

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="dto">Blog Dto</param>
        public void Update(BlogDto dto)
        {
            var blog = this._mapper.Map<Blog>(dto);

            this._blogRepository.Update(blog);
        }

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="dto">Blog Dto</param>
        public void Add(BlogDto dto)
        {
            var blog = this._mapper.Map<Blog>(dto);

            this._blogRepository.Add(blog);
        }
    }
}