using System;
using System.Net;
using System.Web.Http;
using UmderlakareUmbCms.Business.Entities.ViewModel;
using UmderlakareUmbCms.Business.Registries;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Controllers
{
    [IncludeInApiExplorer]
    [RoutePrefix("api/v1/topics")]
    public class ForumTopicController : ApiController
    {

        private readonly ITopicsService _topicsService;

        public ForumTopicController(ITopicsService topicsService)
        {
            _topicsService = topicsService;
        }

        #region HttpGet

        [HttpGet]
        [Route("recentTopics")]
        public IHttpActionResult GetRecentTopics([FromUri] int page = 1, [FromUri]int pageSize = 10)
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

        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAllTopics()
        {
            try
            {
                var topics = _topicsService.GetAllTopics();
                return Ok(topics);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
        }

        [HttpGet]
        [Route("topicByCategoryId/{categoryId:int}")]
        public IHttpActionResult GetTopicByCategoryId(int categoryId, [FromUri] int page = 1, [FromUri]int pageSize = 5, [FromUri]int amountToTake = 10)
        {
            try
            {
                var topics = _topicsService.GetTopicByCategoryId(categoryId, page, pageSize, amountToTake);
                return Ok(topics);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
        }



        #endregion

        #region HttpPut

        [HttpPut]
        [Route("topic/edit")]
        public IHttpActionResult EditTopic(EditTopicViewModel evm)
        {
            try
            {
                _topicsService.EditTopic(evm);
                return Ok();
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.InternalServerError, "something went wrong");
            }
        }



        #endregion

        #region HttpPost

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(CreateTopicViewModel vm)
        {

                try
                {
                    
                    _topicsService.AddTopic(vm);

                    
                    return Ok();
                }
                catch (Exception)
                {

                    return Content(HttpStatusCode.InternalServerError, "something went wrong");
                }
            

        }
        #endregion

        #region HttpDelete
        // Delete topic ska inte kunna deleta enstakade posts förutom hela topic/topicstarter
        [HttpDelete]
        [Route("topic/{id:Guid}")]
        public IHttpActionResult Delete(Guid id)
        {
             try
                {

                    _topicsService.Delete(id);
                    
                    return Ok();
                }
                catch (Exception)
                {
                
                    return Content(HttpStatusCode.InternalServerError, "something went wrong");

                }

           


        }
        #endregion

    }




}