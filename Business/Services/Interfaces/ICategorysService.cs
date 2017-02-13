using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface ICategorysService
    {
        ICategory GetCategoryById(int id);
        IEnumerable<Category> GetAllSubCategories(Guid parentId);
    }
}