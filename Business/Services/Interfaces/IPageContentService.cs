using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface IPageContentService
    {
        IPageContent GetById(Guid Key);
        IPageContent GetLandstingById(Guid Key);
        IPageContent GetAtTjanstById(Guid Key);
    }
}