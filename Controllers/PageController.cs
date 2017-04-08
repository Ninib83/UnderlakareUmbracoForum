using System;
using System.Net;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Registries;
using UmderlakareUmbCms.Business.Services;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Controllers
{
    [IncludeInApiExplorer]
    [RoutePrefix("api/v1/Page")]
    public class PageController : ApiController
    {
        private IPageContentService _contentService;

        public PageController(IPageContentService contentService)
        {
            _contentService = contentService;
        }

        #region HttpGet

        [HttpGet]
        [Route("{key:Guid}")]
        public IHttpActionResult GetPage(Guid key)
        {
            try
            {
                var page = _contentService.GetById(key);
                if (page == null)
                    return Content(HttpStatusCode.NotFound, 
                            new ApiResponse((int)HttpStatusCode.NotFound, "Sidan hittades inte"));

                return Ok(page);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, 
                        new ApiResponse((int)HttpStatusCode.InternalServerError, "Något gick fel"));

            }
        }

        [HttpGet]
        [Route("lansting/{key:Guid}")]
        public IHttpActionResult GetLandstingById(Guid key)
        {
            try
            {
                var page = _contentService.GetLandstingById(key);
                if (page == null)
                    return Content(HttpStatusCode.NotFound,
                            new ApiResponse((int)HttpStatusCode.NotFound, "Sidan hittades inte"));

                return Ok(page);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError,
                        new ApiResponse((int)HttpStatusCode.InternalServerError, "Något gick fel"));

            }
        }

        [HttpGet]
        [Route("atTjanster/{key:Guid}")]
        public IHttpActionResult GetAtTjanstPages(Guid key)
        {
            try
            {
                var page = _contentService.GetAtTjanstById(key);
                if (page == null)
                    return Content(HttpStatusCode.NotFound,
                            new ApiResponse((int)HttpStatusCode.NotFound, "Sidan hittades inte"));

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