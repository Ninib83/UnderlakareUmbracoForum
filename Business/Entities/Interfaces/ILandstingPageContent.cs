using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface ILandstingPageContent
    {
        Guid Key { get; }
        string Name { get; }

        ICollection<PropertieT> Properties { get; }
        IEnumerable<ChildPropertieChild> ChildProperties { get; }
    }
}