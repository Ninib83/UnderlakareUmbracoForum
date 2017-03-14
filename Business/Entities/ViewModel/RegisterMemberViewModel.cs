using Dialogue.Logic.Application;
using Dialogue.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.ViewModel
{
    public class RegisterMemberViewModel
    {
        public int Id { get; set; }


        [Required]
        [DialogueDisplayName("Members.Label.Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DialogueDisplayName("Members.Label.EmailAddress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DialogueDisplayName("Members.Label.Password ")]
        public string Password { get; set; }

        public string SpamAnswer { get; set; }
        public int? ForumId { get; set; }
        public string ReturnUrl { get; set; }
        public string SocialProfileImageUrl { get; set; }
        public string UserAccessToken { get; set; }
    
        public LoginType LoginType { get; set; }
    }
}