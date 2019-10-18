using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Sample.Common.Dto;
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
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        /// <param name="blogService">The blog service.</param>
        public BlogController(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        [ResponseType(typeof(BlogViewModel))]
        [HttpGet]
        [Route("{id}")]
        public BlogViewModel Get(int id)
        {
            var blog = this._blogService.Get(id);

            var model = new BlogViewModel()
            {
                BlogId = blog.BlogId,
                Url = blog.Url
            };

            return model;
        }

        /// <summary>
        /// 取得 Blog
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        [ResponseType(typeof(BlogViewModel))]
        [HttpGet]
        public List<BlogViewModel> GetAll()
        {
            var blogs = this._blogService.GetAll();

            var models = new List<BlogViewModel>();

            foreach (var blog in blogs)
            {
                var model = new BlogViewModel()
                {
                    BlogId = blog.BlogId,
                    Url = blog.Url
                };

                models.Add(model);
            }

            return models;
        }

        /// <summary>
        /// 新增 Blog
        /// </summary>
        /// <param name="parameter">Blog 參數</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(BlogParameter parameter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = new BlogDto()
            {
                BlogId = parameter.BlogId,
                Url = parameter.Url
            };

            this._blogService.Add(dto);

            return Ok();
        }

        /// <summary>
        /// 刪除 Blof
        /// </summary>
        /// <param name="id">Blog Id</param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
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
        [HttpPatch]
        public IHttpActionResult Update(BlogParameter parameter)
        {
            var dto = new BlogDto()
            {
                BlogId = parameter.BlogId,
                Url = parameter.Url
            };

            this._blogService.Update(dto);

            return Ok();
        }
    }
}