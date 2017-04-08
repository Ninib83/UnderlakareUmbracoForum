using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IPropertieT
    {
        int Id { get; }
        string Name { get; }
        object Value { get; }

        


    }
}