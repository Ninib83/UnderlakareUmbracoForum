using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class Member : IMember
    {
        public Member(int id, string userName, string email, string avatar, DateTime? dateCreated,  DateTime? lastLoginDate, int postCount)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Avatar = avatar;
            DateCreated = dateCreated;
            LastLoginDate = lastLoginDate;
            PostCount = postCount;
        }

        public int Id
        {
            get;
        }

        public string UserName
        {
            get;
        }

        public string Email
        {
            get;
        }

        public string Avatar
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

        public int PostCount
        {
            get;
        }
    }
}