using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface ILastPost
    {
         Guid Id { get; }         
         DateTime DateCreated { get;}

         string UserName { get; }
        
    }
}