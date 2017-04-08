using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class PageContent : IPageContent
    {
        public PageContent(Guid key, string name, ICollection<PropertieT> properties, IEnumerable<ChildPropertie> childProperties)
        {
            Key = key;
            Name = name;
            Properties = properties;
            ChildProperties = childProperties;
        }
        public Guid Key
        {
            get;
        }

        public string Name
        {
            get;
        }

        public ICollection<PropertieT> Properties
        {
            get;
        }
        public IEnumerable<ChildPropertie> ChildProperties
        {
            get;

        }
    }
}