using Dialogue.Logic.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Services;

namespace UmderlakareUmbCms.Business.Entities
{
    public class PostPaging : Paging, IPostPaging
    {
        public PostPaging(bool hasMore, int totalMatching, PagedList<Dialogue.Logic.Models.Post> posts)
                    : base(hasMore, totalMatching)
        {

            List<Post> listOfPostsInTopic = new List<Post>();

            foreach (var post in posts)
            {

                var p = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, post.Topic.Id, post.Member.UserName);
                listOfPostsInTopic.Add(p);

            }
            Posts = listOfPostsInTopic.ToList();
        }
        public PostPaging(bool hasMore, int totalMatching, IEnumerable<IPost> posts)
            : base(hasMore, totalMatching)
        {

            Posts = posts;
        }

        public IEnumerable<IPost> Posts
        {
            get;
        }
    }

}