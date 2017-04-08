using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business
{
    public class LandstingPageContent : ILandstingPageContent
    {
        public LandstingPageContent(Guid key, string name, ICollection<PropertieT> properties, IEnumerable<ChildPropertieChild> childProperties)
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
        public IEnumerable<ChildPropertieChild> ChildProperties
        {
            get;
        }
    }
}