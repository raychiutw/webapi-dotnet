using AutoMapper;
using Sample.Common.Dto;
using Sample.Repository.Models;

namespace Sample.Service.Infrastructure
{
    /// <summary>
    /// Service Mapping 定義檔
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProfile"/> class.
        /// </summary>
        public ServiceProfile()
        {
            this.CreateMap<BlogDto, Blog>();
            this.CreateMap<Blog, BlogDto>();
        }
    }
}