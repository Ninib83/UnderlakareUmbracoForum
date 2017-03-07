using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class SubCategory : ISubCategoy
    {
        public SubCategory(int id, string name, int topicCount, int postCount, LastTopic lastTopic, LastPost lastPost)
        {
            Id = id;
            Name = name;
            TopicCount = topicCount;
            PostCount = postCount;
            LastTopic = lastTopic;
            LastPost = lastPost;
        }


        public int Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public int TopicCount
        {
            get;
        }

        public int PostCount
        {
            get;
        }

        public LastTopic LastTopic
        {
            get;
            
        }

        public LastPost LastPost
        {
            get;
            
        }
    }
}
