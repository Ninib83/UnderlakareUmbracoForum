using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.ViewModel
{
    public class LoginMemberViewModel
    {
        public int MemberId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}