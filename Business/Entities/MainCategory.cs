using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class MainCategory : IMainCategory
    {

        public MainCategory(int id, string name, IEnumerable<SubCategory> subCategories)
        {
            Id = id;
            Name = name;
            SubCategories = subCategories;
        }


        public int Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public IEnumerable<SubCategory> SubCategories
        {
            get;
        }
    }
}