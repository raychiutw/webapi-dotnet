using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Sample.Common.Dto;
using Sample.Service.Implement;
using Sample.Service.Interface;
using Sample.WebApi.Controllers.Parameters;
using Sample.WebApi.Controllers.ViewModels;

namespace Sample.WebApi.Controllers
{
    public class BlogController : ApiController
    {
        /// <summary>
        /// The blog service
        /// </summary>
        private IBlogService _blogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogController"/> class.
        /// </summary>
        public BlogController()
        {
            this._blogService = new BlogService();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(BlogViewModel))]
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
        public IHttpActionResult Add(BlogDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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