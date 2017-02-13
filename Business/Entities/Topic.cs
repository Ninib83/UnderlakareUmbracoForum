using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class Topic : ITopic
    {
        public Topic(Guid id, string name, int views, int memberId, DateTime createDate, string slug)
        {
            Id = id;
            Name = name;
            Views = views;
            MemberId = memberId;
            CreateDate = createDate;
            Slug = slug;

        }
        public Guid Id { get; }
        public string Name { get; }
        public int Views { get; }
        public int MemberId { get; }
        public DateTime? CreateDate { get; }
        public  string Slug { get; }

    }
}