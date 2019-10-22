using AutoMapper;
using Sample.Common.Dto;
using Sample.WebApi.Controllers.Parameters;
using Sample.WebApi.Controllers.ViewModels;

namespace Sample.WebApi.Infrastructure
{
    /// <summary>
    /// Controller Mapping 定義檔
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ControllerProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerProfile"/> class.
        /// </summary>
        public ControllerProfile()
        {
            this.CreateMap<BlogParameter, BlogDto>();
            this.CreateMap<BlogDto, BlogViewModel>();
        }
    }
}