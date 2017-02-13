using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IMember
    {
        int Id { get; }
        string UserName { get; }
        string Email { get; }
        string Avatar { get; }
        DateTime? DateCreated { get; }
        DateTime? LastLoginDate { get; }
        string Slug { get; }
        int PostCount { get; }
        string Url { get; }
        string Signature { get; }
    }
}