using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities
{
    public class SubCategoriesId
    {
        public SubCategoriesId(int id, string name, List<Topic> topics)
        {
            Id = id;
            Name = name;
            Topics = topics;

        }

        public int Id
        {
            get;
        }
        public string Name
        {
            get;
        }
        public List<Topic> Topics
        {
            get;
        }
    }
}