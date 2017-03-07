using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Entities
{
    public class Category : ICategory
    {
        
    
        public Category(int id, string name, string description, DateTime? createDate, IEnumerable<Category> subCategories, int topicCount, IEnumerable<Topic> topics, int postCount)
        {
            Id = id;          
            Name = name;
            CreateDate = createDate;
            Description = description;
            SubCategories = subCategories;
            TopicCount = topicCount;
            Topics = topics;
            PostCount = postCount;

        }

       
        public int Id
        {
            get;
        }

        public string Name
        {
            get;
        }

        public string Description
        {
            get;
        }

        public DateTime? CreateDate
        {
            get;
        }

        public IEnumerable<Category> SubCategories
        {
            get;
        }

        public int TopicCount
        {
            get;
            
        }

        public IEnumerable<Topic> Topics
        {
            get;
            
        }

        public int PostCount
        {
            get;
            
        }
    }
}