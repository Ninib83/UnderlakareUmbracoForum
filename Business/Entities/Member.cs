using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class Member : IMember
    {
        public Member(int id, 
                      string username, 
                      string email, 
                      string avatar, 
                      DateTime? dateCreated, 
                      DateTime? lastLoginDate, 
                      string slug, 
                      int postCount,
                      string url,
                      string signature)
        {
            Id = id;
            UserName = username;
            Email = email;
            Avatar = avatar;
            DateCreated = dateCreated;
            LastLoginDate = lastLoginDate;
            PostCount = postCount;
            Url = url;
        }

        public string Avatar
        {
            get;
        }

        public string Email
        {
            get;
        }

        public int Id
        {
            get;
        }

        public string UserName
        {
            get;
        }
        public DateTime? DateCreated
        {
            get;
        }
        public DateTime? LastLoginDate
        {
            get;
        }
        public string Slug
        {
            get;
        }
        public int PostCount
        {
            get;
        }
        public string Url
        {
            get;
        }
        public string Signature
        {
            get;
        }
    }
}