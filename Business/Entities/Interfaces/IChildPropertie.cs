using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IChildPropertie
    {
        int Id { get; }
        string Name { get; }
        object Value { get; }
        IEnumerable<ChildPropertieChild> ChildPropertieChilds { get; }
    }
}