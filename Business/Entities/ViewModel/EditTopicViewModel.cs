using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.ViewModel
{
    public class EditTopicViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PostContent { get; set; }
        public int CategoryId { get; set; }
        public Guid LastPostId { get; set; }
    }
}