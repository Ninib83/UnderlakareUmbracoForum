using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dialogue.Logic.Application;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using Umbraco.Core.Services;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class TopicPaging : Paging, ITopicPaging
    {
        private Dialogue.Logic.Services.PostService _postService = new Dialogue.Logic.Services.PostService();
        
        public TopicPaging(bool hasMore, int totalMatching, PagedList<Dialogue.Logic.Models.Topic> topics)
            :base(hasMore, totalMatching)
        {

            List<Post> listsOfPosts = new List<Post>();
            List<Post> listsOfPostsInTopic = new List<Post>();


            foreach (var topic in topics)
            {
                
                foreach (var post in topic.Posts)
                {
                        var po = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, topic.Member.UserName);
                        listsOfPosts.Add(po);
                   
                }



                foreach (var pos in listsOfPosts)
                {
                    if(pos.TopicId == topic.Id)
                    {
                        var postInTopic = new Post(pos.Id, pos.MemberId, pos.PostContent,pos.DateCreated, pos.TopicId, pos.UserName);
                        listsOfPostsInTopic.Add(postInTopic);
                    }
                }


            }


            Topics = topics.Select(x => new Topic(x.Id, x.MemberId, x.CategoryId, x.Views, x.Name, x.CreateDate, listsOfPostsInTopic));
        }
        public TopicPaging(bool hasMore, int totalMatching, IEnumerable<ITopic> topics) 
            : base(hasMore, totalMatching)
        {
            Topics = topics;
        }

        public IEnumerable<ITopic> Topics
        {
            get;
        }
    }
}