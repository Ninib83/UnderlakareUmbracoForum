using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dialogue.Logic.Models;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class Post : IPost
    {
        public Post(int memberId, string postContent)
        {
            MemberId = memberId;
            PostContent = postContent;
        }
        public int MemberId
        {
            get;
            
        }

        public string PostContent
        {
            get;
            
        }
    }
}