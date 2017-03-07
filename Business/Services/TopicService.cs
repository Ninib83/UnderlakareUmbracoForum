using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using umbraco;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Helpers;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Business.Services
{
    
    public class TopicService : ITopicsService
    {
        private readonly Dialogue.Logic.Services.TopicService _topicService;

        MemberService _memberService = new MemberService(new Dialogue.Logic.Services.MemberService());
        
        public TopicService(Dialogue.Logic.Services.TopicService topicService)
        {
            _topicService = topicService;
        }

        //Klar
        #region Get Resent Topics Request

        public ITopicPaging GetRecentTopics(int page, int pageSize)
        {
            var topics = _topicService.GetRecentTopics(page, pageSize, Int32.MaxValue);
            var hasMore = PagingHelper.HasMore(page, pageSize, topics.TotalCount);
            var results = new TopicPaging(hasMore, topics.TotalCount, topics);

            return results;
        }

        #endregion

        //Klar
        #region Get Topic By TopicId Request

        public ITopic GetTopicById(Guid id)
        {
            var topics = _topicService.Get(id);
            List<Topic> listOfTopics = new List<Topic>();


            
                List<Post> listOfPostsInTopic = new List<Post>();
                foreach (var post in topics.Posts)
                {
                    var member = _memberService.GetMemberById(post.MemberId);
                    var po = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topics.Id, member.UserName);
                    listOfPostsInTopic.Add(po);
                }
            

            return new Topic(topics.Id, topics.MemberId, topics.CategoryId, topics.Views, topics.Name, topics.CreateDate, listOfPostsInTopic);
        }

        #endregion

        //Klar
        #region Get All Topics Request
        public List<Topic> GetAllTopics()
        {
            var topics = _topicService.GetAll();

            List<Topic> listOfTopics = new List<Topic>();

            foreach (var topic in topics)
            {
                List<Post> listOfPostsInTopic = new List<Post>();
                foreach (var post in topic.Posts)
                {
                    var member = _memberService.GetMemberById(post.MemberId);
                    var po = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, member.UserName);
                    listOfPostsInTopic.Add(po);
                }

                var topi = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPostsInTopic);
                listOfTopics.Add(topi);
            }
            return listOfTopics.ToList();
        }
        #endregion

        //Klar
        #region Get All User Topics By MemberId Request

        public IList<Topic> GetAllTopicsByUser(int memberId)
        {
            var topics = _topicService.GetAllTopicsByUser(memberId);
            List<Topic> topicList = new List<Topic>();
            foreach (var topic in topics)
            {
                List<Post> listOfPostsInTopic = new List<Post>();
                foreach (var post in topic.Posts)
                {
                    var member = _memberService.GetMemberById(post.MemberId);
                    var po = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, member.UserName);
                    listOfPostsInTopic.Add(po);
                }

                var customTopic = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPostsInTopic);
                topicList.Add(customTopic);

            }
            return topicList;
        }

        #endregion

        //Fixa logik
        #region Get Topic By CategoryId
        public ITopicPaging GetTopicByCategoryId(int categoryId, int page, int pageSize)
        {
            var topics = _topicService.GetPagedTopicsByCategory(page, pageSize, Int32.MaxValue, categoryId);
            var hasMore = PagingHelper.HasMore(page, pageSize, topics.TotalCount);
            var results = new TopicPaging(hasMore, topics.TotalCount, topics);

            return results;
        }
        #endregion

        //Fixa till Logiken
        #region Delete Topic
        //public Dialogue.Logic.Models.Topic GetByIdForDelete(Guid id)
        //{
        //    var topic = _topicService.Get(id);

        //    return topic;
        //}

        public void Delete(Guid id)
        {

            var topics = _topicService.GetAll();
            foreach (var topic in topics)
            {
                if (topic != null && topic.Id == id)
                {

                    _topicService.Delete(topic);

                }

            }
            

        }

        #endregion

        //Skapa Logik
        #region Update Topic
        #endregion

        //Skapa Logik
        #region Create New Topic

        //public void AddTopic([FromBody]JObject json)
        //{
        //    CreateTopicViewModel t = JsonConvert.DeserializeObject<CreateTopicViewModel>(json.ToString());

        //    string topicName = t.TopicName;
        //    int categoryId = t.CategoryId;
        //    int memberId = t.MemberId;

        //    Dialogue.Logic.Models.Topic dt = new Dialogue.Logic.Models.Topic();
        //    dt.Name = topicName;
        //    dt.CategoryId = categoryId;
        //    dt.MemberId = memberId;
        //    _topicService.Add(dt);


        //}


        public void AddTopi(CreateTopicViewModel vm)
        {
            //string topicContent;
            Dialogue.Logic.Models.Topic dt = new Dialogue.Logic.Models.Topic();
         
            //if (!string.IsNullOrEmpty(vm.TopicContent))
            //{
                dt.Name = vm.TopicName;
                dt.Category = vm.Category;
                dt.CategoryId = vm.CategoryId;
                dt.Member = vm.Member;
                dt.MemberId = vm.MemberId;

                //topicContent = vm.TopicContent;
                _topicService.Add(dt);
           // }
                


        }

        #endregion

    }
}