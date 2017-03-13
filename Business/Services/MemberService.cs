using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Services.Interfaces;
using UmderlakareUmbCms.Business.Entities;
using Dialogue.Logic.Application;

namespace UmderlakareUmbCms.Business.Services
{
    public class MemberService : IMembersService
    {
        private Dialogue.Logic.Services.MemberService _memberService;

        public MemberService(Dialogue.Logic.Services.MemberService memberService)
        {
            _memberService = memberService;
        }

        public bool Login(string username, string password)
        {
            
            var member = _memberService.Login(username, password);
            return AppHelpers.UmbMemberHelper().Login(username, password);
            
            
        }

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