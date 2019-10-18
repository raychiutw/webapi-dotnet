using System;
using System.Collections.Generic;
using Sample.Common.Dto;
using Sample.Service.Implement;

namespace Sample.Service.Interface
{
    public class BlogService : IBlogService
    {
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BlogDto blog)
        {
            throw new NotImplementedException();
        }

        public void Add(BlogDto blog)
        {
            throw new NotImplementedException();
        }
    }
}