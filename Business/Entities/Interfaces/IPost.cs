using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IPost
    {

        Guid Id { get; }
        int MemberId { get; }
        string PostContent { get; }
        Guid TopicId { get; }

        DateTime DateCreated { get; }
        string UserName { get; }

    }
}