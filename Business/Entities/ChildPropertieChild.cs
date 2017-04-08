using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class ChildPropertieChild : IChildPropertieChild
    {
        public ChildPropertieChild(int id, string name, IEnumerable<PropertieT> properties)
        {
            Id = id;
            Name = name;
            Properties = properties;
        }
        public int Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public IEnumerable<PropertieT> Properties
        {
            get;
        }
    }
}