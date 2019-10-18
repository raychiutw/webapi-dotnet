using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Sample.Common.Dto;
using Sample.Service.Interface;
using Sample.WebApi.Controllers.Parameters;
using Sample.WebApi.Controllers.ViewModels;

namespace Sample.WebApi.Controllers
{
    [RoutePrefix("api/blog")]
    public class BlogController : ApiController
    {
        /// <summary>
        /// The blog service
        /// </summary>
        private IBlogService _blogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        public BlogController(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(BlogViewModel))]
        [HttpGet]
        [Route("{id}")]
        public List<BlogViewModel> Get(int id)
        {
            var blogs = this._blogService.Get(id);

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

        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            this._blogService.Remove(id);

            return Ok();
        }

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