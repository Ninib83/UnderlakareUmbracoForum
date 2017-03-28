using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface ITopic
    {
        Guid Id { get; }
        int MemberId { get; }
        int CategoryId { get; }
        int Views { get; }
        string Name { get;}
        DateTime CreateDate { get; }
        List<Post> Posts { get; }
        string UserName { get; }
        DateTime? MemberDateCreate { get; }
    }
}
