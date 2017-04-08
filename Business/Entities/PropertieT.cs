using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class PropertieT : IPropertieT
    {
        public PropertieT(int id, string name, object value)
        {
            
            Id = id;
            Name = name;
            Value = value;
            
        }



        public int Id
        {
            get;
        }
        public string Name
        {
            get;
        }
        public object Value
        {
            get;
        }
    }
}