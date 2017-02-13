using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Services.Interfaces;
using UmderlakareUmbCms.Business.Entities;

namespace UmderlakareUmbCms.Business.Services
{
    public class MemberService : IMembersService
    {
        private readonly Dialogue.Logic.Services.MemberService _memberService;

        public MemberService(Dialogue.Logic.Services.MemberService memberService)
        {
            _memberService = memberService;
        }

        public IMember GetMemberByEmail(string email)
        {
            var member = _memberService.GetByEmail(email);
            return new Member(member.Id,
                              member.UserName,
                              member.Email, 
                              member.Avatar, 
                              member.DateCreated, 
                              member.LastLoginDate, 
                              member.Slug,
                              member.PostCount,
                              member.Url,
                              member.Signature);
        }

        public IMember GetMemberById(int id)
        {
            var member = _memberService.Get(id);
            return new Member(member.Id, 
                              member.UserName, 
                              member.Email, 
                              member.Avatar, 
                              member.DateCreated, 
                              member.LastLoginDate, 
                              member.Slug,
                              member.PostCount,
                              member.Url,
                              member.Signature);
        }

        public IMember GetMemberByUsername(string username)
        {
            var member = _memberService.GetByUsername(username);
            return new Member(member.Id, 
                              member.UserName, 
                              member.Email, 
                              member.Avatar, 
                              member.DateCreated, 
                              member.LastLoginDate, 
                              member.Slug,
                              member.PostCount,
                              member.Url,
                              member.Signature);
        }
    }
}