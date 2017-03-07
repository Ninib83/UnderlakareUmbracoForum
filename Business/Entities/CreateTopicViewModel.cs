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

        public Dialogue.Logic.Models.Member Member { get; set; }

        public Dialogue.Logic.Models.Category Category { get; set; }


       // public string TopicContent { get; set; }

    }
}