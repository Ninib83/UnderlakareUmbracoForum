using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class LastTopic : ILastTopic
    {


        public LastTopic(Guid id, string name, DateTime createDate)
        {
            Id = id;
            Name = name;
            CreateDate = createDate;
        }


        public Guid Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public DateTime CreateDate
        {
            get;


        }
    }
}