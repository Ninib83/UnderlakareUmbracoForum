using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Entities;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface IMembersService
    {
        //IEnumerable<Member> GetAllMembers();
        IMember GetMemberById(int id);
        IMember GetMemberByUsername(string username);
        IMember GetMemberByEmail(string email);
    }
}