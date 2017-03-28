using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface ISubCategoriesId
    {
        int Id { get; }
        string Name { get; }
        List<Topic> Topics { get; }
    }
}