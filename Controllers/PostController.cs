using Dialogue.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
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


        //[HttpGet]
        //[Route("")]
        //public IHttpActionResult GetAllPosts([FromUri] int page = 1, [FromUri]int pageSize = 10)
        //{
        //    try
        //    {
        //        var posts = _postsService.GetRecentPosts(page, pageSize);
        //        return Ok(posts);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        return Content(HttpStatusCode.InternalServerError, "Något gick fel");
        //    }
        //}


        [HttpGet]
        [Route("{memberId:int}")]
        public IHttpActionResult GetPostByMemberId(int memberId)
        {
            try
            {
                var posts = _postsService.GetPostByMemberId(memberId);
                return Ok(posts);
            }
            catch (Exception)
            {

                return Content(HttpStatusCode.InternalServerError, "Något har hänt!");
            }
        }



        

    }
}