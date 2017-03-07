using System;
using System.Net;
using System.Web.Http;
using Umbraco.Core.Services;
using UmderlakareUmbCms.Business.Entities;

namespace UmderlakareUmbCms.Controllers
{
    [RoutePrefix("api/v1/blogs")]
    public class PageController : ApiController
    {
        private readonly IContentService _contentService;
        public PageController(IContentService contentService)
        {
            _contentService = contentService;
        }

        #region HttpGet

        [HttpGet]
        [Route("{id:Guid}")]
        public IHttpActionResult GetPage(Guid id)
        {
            try
            {
                var page = _contentService.GetById(id);
                if (page == null)
                    return Content(HttpStatusCode.NotFound, 
                            new ApiResponse((int)HttpStatusCode.NotFound, "Blogposten hittades inte"));

                return Ok(page);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, 
                        new ApiResponse((int)HttpStatusCode.InternalServerError, "Något gick fel"));

            }
        }

        #endregion

    }
}