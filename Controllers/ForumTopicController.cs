using Dialogue.Logic.Data.Context;
using Dialogue.Logic.Data.UnitOfWork;
using Dialogue.Logic.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Web.Http;
using UmderlakareUmbCms.Business.Entities;
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

        //[HttpGet]
        //[Route("{categoryId:int}")]
        //public IHttpActionResult GetTopicByCategoryId(int categoryId, [FromUri] int page = 1, [FromUri]int pageSize = 5)
        //{
        //    try
        //    {
        //        var topics = _topicsService.GetTopicByCategoryId(page, pageSize, categoryId);
        //        return Ok(topics);
        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine(e);
        //        return Content(HttpStatusCode.InternalServerError, "Något gick fel");
        //    }
        //}



        #endregion

        #region HttpPut
        #endregion

        #region HttpPost

        [HttpPost]
        [Route("add")]
        public IHttpActionResult Add(CreateTopicViewModel vm)
        {
            var UnitOfWorkManager = new UnitOfWorkManager(ContextPerRequest.Db);
            using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
            {
                try
                {
                    // Do all logic here
                    _topicsService.AddTopi(vm);
                    // Commit the transaction
                   unitOfWork.Commit();
                    //unitOfWork.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    // Roll back database changes 
                    unitOfWork.Rollback();
                    // Log the error
                    return Content(HttpStatusCode.InternalServerError, "something went wrong");

                    // Do what you want
                }
            }

        }


        #endregion

        #region HttpDelete

        [HttpDelete]
        [Route("{id:Guid}")]
        public IHttpActionResult Delete(Guid id)
        {


            try
            {

                _topicsService.Delete(id);              
                return Ok();
            }
            catch (Exception e)
            {


                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
        }
        #endregion

    }




}