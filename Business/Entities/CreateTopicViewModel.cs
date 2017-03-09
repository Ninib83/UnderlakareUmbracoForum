using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities
{
    public class CreateTopicViewModel
    {
        public string TopicName
        {
            get; set;
        }
        public int CategoryId
        {
            get; set;
        }
        public int MemberId
        {
            get; set;
        }
        public string TopicContent
        {
            get; set;
        }

    }
}