using System.Collections.Generic;
using Sample.Common.Dto;

namespace Sample.Service.Implement
{
    public interface IBlogService
    {
        IEnumerable<BlogDto> Get(int id);

        void Update(BlogDto blog);

        void Add(BlogDto blog);

        void Remove(int id);
    }
}