﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface ICategorysService
    {
        IEnumerable<MainCategory> GetAllMainAndSubCategories();
        IEnumerable<SubCategory> GetAllSubCategories();
        IMainCategory GetMainCategoryById(int id);
        IEnumerable<SubCategoriesId> GetSubCategoryById(int id);

    }
}