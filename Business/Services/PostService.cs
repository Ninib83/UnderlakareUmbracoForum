using System;
using System.Collections.Generic;
using System.Linq;
using Dialogue.Logic.Models;
using UmderlakareUmbCms.Business.Services.Interfaces;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Helpers;
using Post = UmderlakareUmbCms.Business.Entities.Post;


namespace UmderlakareUmbCms.Business.Services
{
    public class PostService : IPostsService
    {
        private readonly Dialogue.Logic.Services.PostService _postService;
        List<Post> postList = new List<Post>();
       

        public PostService(Dialogue.Logic.Services.PostService postService)
        {
            _postService = postService;
            
        }

        //public IPostPaging GetRecentPosts(int page, int pageSize)
        //{
        //    var posts = _postService.GetPagedPostsByTopic(page, pageSize, Int32.MaxValue);
        //    var hasMore = PagingHelper.HasMore(page, pageSize, Int32.MaxValue);
        //    var results = new TopicPaging(hasMore, posts.TotalCount, posts);

        //    return results;
        //}



        public List<Post> GetPostByMemberId(int memberId)
        {
            var posts = _postService.GetByMember(memberId).ToList();
            
            foreach(var ps in posts)
            {
                var customPost = new Post(ps.MemberId, ps.PostContent);
                postList.Add(customPost);
                
            }

            return postList;
        }


       


    }

}