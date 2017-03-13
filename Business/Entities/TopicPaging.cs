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

            
            List<Topic> listOfTopicInCat = new List<Topic>();

           

            foreach (var topic in topics)
            {
                List<Post> listOfPosts = new List<Post>();

                foreach (var post in topic.Posts)
                {
                        var po = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, topic.Member.UserName);
                        listOfPosts.Add(po);
                   
                }

                var topi = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPosts);
                listOfTopicInCat.Add(topi);
               
            }

            //Topics = topics.Select(x => new Topic(x.Id, x.MemberId, x.CategoryId, x.Views, x.Name, x.CreateDate, listOfPosts));
            Topics = listOfTopicInCat.ToList();


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