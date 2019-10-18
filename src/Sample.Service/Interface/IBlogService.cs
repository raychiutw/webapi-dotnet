using System.Collections.Generic;
using Sample.Common.Dto;

namespace Sample.Service.Interface
{
    public interface IBlogService
    {
        List<BlogDto> Get(int id);

        void Update(BlogDto dto);

        void Add(BlogDto dto);

        void Remove(int id);
    }
}