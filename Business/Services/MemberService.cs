using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Services.Interfaces;
using UmderlakareUmbCms.Business.Entities;
using Dialogue.Logic.Application;
using UmderlakareUmbCms.Business.Entities.ViewModel;
using Umbraco.Web.Security;
using System.Web.Security;
using Umbraco.Web;
using Umbraco.Core;

namespace UmderlakareUmbCms.Business.Services
{
    public class MemberService : IMembersService
    {
        private Dialogue.Logic.Services.MemberService _memberService;
        private MembershipHelper membershipHelper = new MembershipHelper(UmbracoContext.Current);

        public MemberService(Dialogue.Logic.Services.MemberService memberService)
        {
            _memberService = memberService;
        }

        //Klar
        #region Register

        public void Register(RegisterMemberViewModel vm)
        {
            var loginType = Dialogue.Logic.Models.LoginType.Standard;
            vm.LoginType = loginType;

            Umbraco.Core.Models.IMember _newMember = ApplicationContext.Current.Services.MemberService.CreateMember(vm.UserName, vm.Email, vm.UserName, "DialogueMember");
            ApplicationContext.Current.Services.MemberService.Save(_newMember, false);
            ApplicationContext.Current.Services.MemberService.SavePassword(_newMember, vm.Password);
            ApplicationContext.Current.Services.MemberService.AssignRole(_newMember.Id, "Dialogue Standard");

        }

        #endregion


        #region Login
        public void Login(LoginMemberViewModel vm)
        {

            if (membershipHelper.Login(vm.UserName, vm.Password))
            {
                membershipHelper.GetCurrentLoginStatus();
                bool status = membershipHelper.IsLoggedIn();
            }
        }

        #endregion

        #region LogOut
        public void LogOff()
        {

            if(membershipHelper.IsLoggedIn())
            {
                membershipHelper.Logout();
            }

        }
        #endregion

       
        //Klar
        #region Get Member By Email Request
        public IMember GetMemberByEmail(string email)
        {
            var member = _memberService.GetByEmail(email);
            return new Member(member.Id,
                              member.UserName,
                              member.Email, 
                              member.Avatar, 
                              member.DateCreated, 
                              member.LastLoginDate,
                              member.PostCount);
        }

        #endregion

        //Klar
        #region Get Member By Id Request

        public IMember GetMemberById(int id)
        {
            var member = _memberService.Get(id);
            return new Member(member.Id, 
                              member.UserName, 
                              member.Email, 
                              member.Avatar, 
                              member.DateCreated, 
                              member.LastLoginDate, 
                              member.PostCount);
        }

        #endregion

        //Klar
        #region Get Member By UserName Request

        public IMember GetMemberByUsername(string username)
        {
            var member = _memberService.GetByUsername(username);
            return new Member(member.Id, 
                              member.UserName, 
                              member.Email, 
                              member.Avatar, 
                              member.DateCreated, 
                              member.LastLoginDate, 
                              member.PostCount);
        }


        #endregion
    }
}