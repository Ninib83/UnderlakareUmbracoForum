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
        IEnumerable<MainCategory> GetAllMainAndSubCategories();
        IEnumerable<SubCategory> GetAllSubCategories();
        IMainCategory GetMainCategoryById(int id);
        ISubCategoy GetSubCategoryById(int id);

        //ITopicPaging GetTopicsByCategory(int page, int size, int categoryId);




    }
}