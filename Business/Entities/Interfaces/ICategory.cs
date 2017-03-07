using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface ICategory
    {
        int Id { get; }
        string Name { get; }
        string Description { get; }
        DateTime? CreateDate { get; }
        IEnumerable<Category> SubCategories { get; }
        int TopicCount { get; }
        IEnumerable<Topic> Topics { get; }
        int PostCount { get; }

    }
}