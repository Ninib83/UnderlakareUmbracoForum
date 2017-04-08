using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IPageContent
    {
        Guid Key { get; }
        string Name { get; }

        ICollection<PropertieT> Properties { get; }
        IEnumerable<ChildPropertie> ChildProperties { get; }

    }
}