using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities
{
    public class CreatePostViewModel
    {
        public string PostContent { get; set; }

        public string TopicId { get; set; }

        public int MemberId { get; set; }


    }
}