using Dialogue.Logic.Application.Akismet;
using Dialogue.Logic.Data.Context;
using Dialogue.Logic.Data.UnitOfWork;
using Dialogue.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Services;
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

        //[HttpGet]
        //[Route("")]
        //public IHttpActionResult GetPostsByTopicId([FromUri] int page = 1, [FromUri]int pageSize = 10)
        //{
        //    try
        //    {
        //        var posts = _postsService.GetPostsByTopicId(page, pageSize);
        //        return Ok(posts);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return Content(HttpStatusCode.InternalServerError, "Något gick fel");
        //    }
        //}


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
        [Route("{memberId:int}")]
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
        [Route("addpost")]
        public IHttpActionResult Edit(CreatePostViewModel vm)
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

        #region HttpDelete

        [HttpDelete]
        [Route("{id:Guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            var UnitOfWorkManager = new UnitOfWorkManager(ContextPerRequest.Db);
            using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
            {
                try
                {

                    _postsService.Delete(id);
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

    }
}