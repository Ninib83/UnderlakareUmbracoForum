using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class ChildPropertie : IChildPropertie
    {

        public ChildPropertie(int id, string name, object value, IEnumerable<ChildPropertieChild> childPropertieChilds)
        {
            Id = id;
            Name = name;
            Value = value;
            ChildPropertieChilds = childPropertieChilds;
        }
        public int Id { get; }

        public string  Name { get; }

        public object Value { get; }
        public IEnumerable<ChildPropertieChild> ChildPropertieChilds { get; }

    }
}