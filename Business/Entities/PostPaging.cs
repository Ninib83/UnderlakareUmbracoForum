using Dialogue.Logic.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class PostPaging : Paging, IPostPaging
    {


        public PostPaging(bool hasMore, int totalMatching, PagedList<Dialogue.Logic.Models.Post> posts)
            : base(hasMore, totalMatching)
        {
            Posts = posts.Select(x => new Post(x.MemberId, x.PostContent));
        }

        public PostPaging(bool hasMore, int totalMatching, IEnumerable<IPost> posts)
            : base(hasMore, totalMatching)
        {
            Posts = posts;
        }


        public IEnumerable<IPost> Posts { get; }
    }
}