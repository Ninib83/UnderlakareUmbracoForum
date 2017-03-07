using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IMainCategory
    {
        int Id { get; }
        string Name { get; }
        IEnumerable<SubCategory> SubCategories { get; }
    }
}