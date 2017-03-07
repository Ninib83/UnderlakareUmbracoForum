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

        public Post(Guid id, int memberId, string postContent, DateTime dateCreated, Guid topicId, string userName)
        {
            Id = id;
            MemberId = memberId;
            PostContent = postContent;
            DateCreated = dateCreated;
            TopicId = topicId;
            UserName = userName;

        }

        public DateTime DateCreated
        {
            get;
            
        }

        public Guid Id
        {
            get;
           
        }

        public int MemberId
        {
            get;
            
        }

        public string PostContent
        {
            get;
            
        }

        public Guid TopicId
        {
            get;
            
        }

        public string UserName
        {
            get;
        }
    }
}