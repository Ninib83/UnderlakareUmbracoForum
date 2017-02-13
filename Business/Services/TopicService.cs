using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Helpers;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Business.Services
{
    
    public class TopicService : ITopicsService
    {
        private readonly Dialogue.Logic.Services.TopicService _topicService;

        List<Topic> topicList = new List<Topic>();
        public TopicService(Dialogue.Logic.Services.TopicService topicService)
        {
            _topicService = topicService;
        }

        public ITopicPaging GetRecentTopics(int page, int pageSize)
        {
            var topics = _topicService.GetRecentTopics(page, pageSize, Int32.MaxValue);
            var hasMore = PagingHelper.HasMore(page, pageSize, topics.TotalCount);
            var results = new TopicPaging(hasMore, topics.TotalCount, topics);

            return results;
        }

        public ITopic GetTopicById(Guid id)
        {
            var topic = _topicService.Get(id);
            return new Topic(topic.Id, topic.Name, topic.Views, topic.MemberId, topic.CreateDate, topic.Slug);
        }

        public IList<Topic> GetAllTopicsByUser(int memberId)
        {
            var topics = _topicService.GetAllTopicsByUser(memberId);

            foreach (var tc in topics)
            {
                var customTopic = new Topic(tc.Id, tc.Name, tc.Views, tc.MemberId, tc.CreateDate, tc.Slug);
                topicList.Add(customTopic);

            }
            return topicList;
        }
    }
}