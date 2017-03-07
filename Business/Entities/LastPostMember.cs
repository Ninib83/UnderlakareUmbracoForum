using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class LastPostMember : ILastPostMember
    {
        public LastPostMember(string userName)
        {
            UserName = userName;
        }

        public string UserName
        {
            get;
        }
    }
}