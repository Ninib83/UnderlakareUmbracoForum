using Dialogue.Logic.Constants;
using Dialogue.Logic.Data.Context;
using Dialogue.Logic.Data.UnitOfWork;
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
        private Dialogue.Logic.Services.TopicService _topicService;
        

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

        //Klar
        #region Create New Topic


        public void AddTopic(CreateTopicViewModel vm)
        {
            var UnitOfWorkManager = new UnitOfWorkManager(ContextPerRequest.Db);
            using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
            {

                Dialogue.Logic.Services.CategoryService catServ = new Dialogue.Logic.Services.CategoryService();
                Dialogue.Logic.Services.MemberService memberServ = new Dialogue.Logic.Services.MemberService();
                Dialogue.Logic.Services.PermissionService _permissionService = new Dialogue.Logic.Services.PermissionService();

                string topicContent;
                Dialogue.Logic.Models.Topic dt = new Dialogue.Logic.Models.Topic();

                dt.Name = vm.TopicName;
                dt.CreateDate = DateTime.UtcNow;

                dt.CategoryId = vm.CategoryId;
                dt.MemberId = vm.MemberId;
                topicContent = vm.TopicContent;

                var category = catServ.Get(dt.CategoryId);
                var member = memberServ.Get(dt.MemberId);
                Dialogue.Logic.Models.PermissionSet permissions = _permissionService.GetPermissions(category, member.Groups.FirstOrDefault());

                if (permissions[AppConstants.PermissionCreateTopics].IsTicked && !permissions[AppConstants.PermissionReadOnly].IsTicked && !permissions[AppConstants.PermissionDenyAccess].IsTicked && permissions[AppConstants.PermissionCreatePolls].IsTicked && permissions[AppConstants.PermissionAttachFiles].IsTicked)
                {

                    _topicService.Add(dt);
                    unitOfWork.SaveChanges();
                    _topicService.AddLastPost(dt, topicContent);
                    unitOfWork.Commit();
                }

            }
        }



        #endregion

    }
}