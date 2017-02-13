using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dialogue.Logic.Services;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Services.Interfaces;
using UmderlakareUmbCms.Business.Entities;

namespace UmderlakareUmbCms.Business.Services
{
    public class CategoryService : ICategorysService
    {
        private readonly Dialogue.Logic.Services.CategoryService _categoryService;
        List<Category> totalSubCatList = new List<Category>();
        public CategoryService(Dialogue.Logic.Services.CategoryService categoryService )
        {
            _categoryService = categoryService;
        }

        public IEnumerable<Category> GetAllSubCategories(Guid parentId)
        {

            var subCats = _categoryService.GetAllSubCategories(parentId);
            
            foreach(var sub in subCats)
            {
                foreach(var s in sub.Children)
                {
                    var subs = new Category(s.Id, s.Name, s.CreateDate);
                    totalSubCatList.Add(subs);
                }
            }   
            
            return totalSubCatList;
        }

        public ICategory GetCategoryById(int id)
        {
            var category = _categoryService.Get(id);
            
            return new Category(category.Id,
                                 category.Name,
                                 category.CreateDate);
        }
    }
}