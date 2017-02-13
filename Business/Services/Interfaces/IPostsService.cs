using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Entities;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface IPostsService
    {
        List<Post> GetPostByMemberId(int memberId);

    }
}