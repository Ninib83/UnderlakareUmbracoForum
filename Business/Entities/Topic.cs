using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class Topic : ITopic
    {
        public Topic(Guid id, int memberId, int categoryId, int views, string name, DateTime createDate, List<Post> posts)
        {
            Id = id;
            CategoryId = categoryId;
            MemberId = memberId;
            Views = views;
            Name = name;
            CreateDate = createDate;          
            Posts = posts;
            
            

        }
        public Guid Id
        {
            get;
        }

        public int MemberId
        {
            get;
        }

        public int CategoryId
        {
            get;
        }

        public int Views
        {
            get;
        }

        public string Name
        {
            get;
        }

        public DateTime CreateDate
        {
            get;
        }

        public List<Post> Posts
        {
            get;
            
        }

    }
}