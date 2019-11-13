using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Sample.Common.Dto;
using Sample.Infrastructure;
using Sample.Service.Interface;
using Sample.WebApi.Controllers.Parameters;
using Sample.WebApi.Controllers.ViewModels;

namespace Sample.WebApi.Controllers
{
    /// <summary>
    /// Blog Controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/blog")]
    public class BlogController : ApiController
    {
        /// <summary>
        /// The blog service
        /// </summary>
        private readonly IBlogService _blogService;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        /// <param name="blogService">The blog service.</param>
        /// <param name="mapper">The mapper.</param>
        public BlogController(
            IBlogService blogService,
            IMapper mapper)
        {
            this._blogService = blogService;
            this._mapper = mapper;
        }

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        [NanoProfiling]
        [ResponseType(typeof(BlogViewModel))]
        [HttpGet]
        [Route("{id}")]
        public BlogViewModel Get(int id)
        {
            var dto = this._blogService.Get(id);

            var viewModel = this._mapper.Map<BlogViewModel>(dto);

            return viewModel;
        }

        ///// <summary>
        ///// 取得 Blog
        ///// </summary>
        ///// <param name="id">Blog Id</param>
        ///// <returns></returns>
        //[ResponseType(typeof(BlogViewModel))]
        //[HttpGet]
        //public List<BlogViewModel> GetAll()
        //{
        //    var dtos = this._blogService.GetAll();

        //    var viewModels = this._mapper.Map<List<BlogViewModel>>(dtos);

        //    return viewModels;
        //}

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="parameter">Blog Id</param>
        /// <returns></returns>
        [NanoProfiling(ProfilingName = "BlogController - GetRange")]
        [ResponseType(typeof(BlogViewModel))]
        [HttpGet]
        public IEnumerable<BlogViewModel> GetRange([FromUri]BlogQueryParameter parameter)
        {
            var query = this._mapper.Map<BlogQueryDto>(parameter);

            var blogs = this._blogService.GetRange(query);

            var viewModels = this._mapper.Map<IEnumerable<BlogViewModel>>(blogs);

            return viewModels;
        }

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="parameter">Blog 參數</param>
        /// <returns></returns>
        [NanoProfiling]
        [HttpPost]
        public IHttpActionResult Add(BlogParameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = this._mapper.Map<BlogDto>(parameter);

            this._blogService.Add(dto);

            return Ok();
        }

        /// <summary>
        /// 刪除 Blof
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        [NanoProfiling]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Remove(int id)
        {
            this._blogService.Remove(id);

            return Ok();
        }

        /// <summary>
        /// 更新 Blog
        /// </summary>
        /// <param name="parameter">Blog 參數</param>
        /// <returns></returns>
        [NanoProfiling]
        [HttpPatch]
        public IHttpActionResult Update(BlogParameter parameter)
        {
            var dto = this._mapper.Map<BlogDto>(parameter);

            this._blogService.Update(dto);

            return Ok();
        }
    }
}