using Dialogue.Logic.Data.Context;
using Dialogue.Logic.Data.UnitOfWork;
using Dialogue.Logic.Models;
using System;
using System.Net;
using System.Web.Http;
using UmderlakareUmbCms.Business.Entities.ViewModel;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UnderlakareCmsDialogue.Controllers
{
    [RoutePrefix("api/v1/posts")]
    public class PostController : ApiController
    {
        private readonly IPostsService _postsService;

        public PostController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        #region HttpGet

        [HttpGet]
        [Route("postByTopicId/{topicId:Guid}")]
        public IHttpActionResult GetPostsByTopicId(Guid topicId, [FromUri] int pageIndex = 1, [FromUri]int pageSize = 10, [FromUri]int amountToTake = 10, [FromUri] PostOrderBy order = 0)
        {
            try
            {
                var posts = _postsService.GetPostsByTopicId(topicId, pageIndex, pageSize, amountToTake, order);
                return Ok(posts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
        }


        [HttpGet]
        [Route("allPosts")]
        public IHttpActionResult GetAllPosts()
        {
            try
            {
                var posts = _postsService.GetAllPosts();
                return Ok(posts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något gick fel");
            }
        }

        [HttpGet]
        [Route("getPostById/{id:Guid}")]
        public IHttpActionResult GetPostById(Guid id)
        {
            try
            {
                var posts = _postsService.GetPostById(id);
                return Ok(posts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }



        [HttpGet]
        [Route("getPostByMembetId/{memberId:int}")]
        public IHttpActionResult GetPostByMemberId(int memberId)
        {
            try
            {
                var posts = _postsService.GetPostByMemberId(memberId);
                return Ok(posts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }



        #endregion

        #region HttpPost
        

        [HttpPost]
        [Route("addpost")]
        public IHttpActionResult Add(CreatePostViewModel vm)
        {
            var UnitOfWorkManager = new UnitOfWorkManager(ContextPerRequest.Db);
            using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
            {
                try
                {

                    _postsService.AddPost(vm);
                    unitOfWork.Commit();
                    
                    return Ok();
                }
                catch (Exception)
                {
 
                    unitOfWork.Rollback();
                    return Content(HttpStatusCode.InternalServerError, "something went wrong");
                }
            }

        }

        #endregion

        #region HttpPut


        [HttpPut]
        [Route("post/edit")]
        public IHttpActionResult EditPost(EditPostViewModel evm)
        {
            try
            {
                _postsService.EditPost(evm);
                return Ok();
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.InternalServerError, "something went wrong");
            }
        }

        #endregion

        #region HttpDelete

        //Delete post and topic
        [HttpDelete]
        [Route("post/{id:Guid}")]
        public IHttpActionResult DeletePostAndTopic(Guid id)
        {
            try
            {
                _postsService.Delete(id);
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