using System.Collections.Generic;
using Sample.Common.Dto;
using Sample.Repository.Interface;
using Sample.Repository.Models;
using Sample.Service.Interface;

namespace Sample.Service.Implement
{
    public class BlogService : IBlogService
    {
        private readonly IBologRepository _blogRepository;

        public BlogService(IBologRepository bologRepository)
        {
            this._blogRepository = bologRepository;
        }

        public void Remove(int id)
        {
            this._blogRepository.Remove(id);
        }

        public List<BlogDto> Get(int id)
        {
            var blogs = this._blogRepository.Get(x => x.BlogId == id);

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

        public void Update(BlogDto dto)
        {
            var blog = new Blog()
            {
                BlogId = dto.BlogId,
                Url = dto.Url
            };

            this._blogRepository.Update(blog);
        }

        public void Add(BlogDto dto)
        {
            var blog = new Blog()
            {
                BlogId = dto.BlogId,
                Url = dto.Url
            };

            this._blogRepository.Add(blog);
        }
    }
}