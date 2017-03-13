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
        IMember GetMemberById(int id);
        IMember GetMemberByUsername(string username);
        IMember GetMemberByEmail(string email);
        bool Login(string username, string password);
        //virtual RegisterModel CreateRegistrationModel(string memberTypeAlias = null);
    }
}