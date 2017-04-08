using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IChildPropertieChild
    {
        int Id { get; }
        string Name { get; }
        IEnumerable<PropertieT> Properties{get;}

    }
}