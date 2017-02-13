using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dialogue.Logic.Application;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class TopicPaging : Paging, ITopicPaging
    {
        public TopicPaging(bool hasMore, int totalMatching, PagedList<Dialogue.Logic.Models.Topic> topics)
            :base(hasMore, totalMatching)
        {
            Topics = topics.Select(x => new Topic(x.Id, x.Name, x.Views, x.MemberId, x.CreateDate, x.Slug));
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