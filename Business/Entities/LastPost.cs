using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class LastPost : ILastPost
    {

        public LastPost(Guid id, DateTime dateCreated , string userName)
        {
            Id = id;
            DateCreated = dateCreated;
            UserName = userName;
            


        }


        public Guid Id
        {
            get;
        }

        public DateTime DateCreated
        {
            get;

        }

        public string UserName
        {
            get;
        }
    }
}