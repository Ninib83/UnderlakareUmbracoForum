using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.ViewModel;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface IMembersService
    {
        IMember GetMemberById(int id);
        IMember GetMemberByUsername(string username);
        IMember GetMemberByEmail(string email);
        void ResetPassword(Dialogue.Logic.Models.Member member, string newPassword);
        void Register(RegisterMemberViewModel vm);
        void Login(LoginMemberViewModel vm);
        void LogOff();
        bool IsLoggedIn();
    }
}