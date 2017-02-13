using System;
using System.Net;
using System.Web.Http;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Controllers
{
    [RoutePrefix("api/v1/topics")]
    public class ForumTopicController : ApiController
    {

        private readonly ITopicsService _topicsService;

        public ForumTopicController(ITopicsService topicsService)
        {
            _topicsService = topicsService;
        }

       
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTopics([FromUri] int page = 1, [FromUri]int pageSize = 5)
        {
            try
            {
                var topics = _topicsService.GetRecentTopics(page, pageSize);
                return Ok(topics);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IHttpActionResult GetTopicById(Guid id)
        {
            try
            {
                var topic = _topicsService.GetTopicById(id);
                return Ok(topic);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
          
        }
        [HttpGet]
        [Route("{memberId:int}")]
        public IHttpActionResult GetAllTopicsByUser(int memberId)
        {
            try
            {
                var topic = _topicsService.GetAllTopicsByUser(memberId);
                return Ok(topic);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
        }
    }
}