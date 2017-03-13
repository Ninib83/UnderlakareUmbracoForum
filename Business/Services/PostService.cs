using System;
using System.Collections.Generic;
using System.Linq;
using Dialogue.Logic.Models;
using UmderlakareUmbCms.Business.Services.Interfaces;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Helpers;
using Post = UmderlakareUmbCms.Business.Entities.Post;
using System.Net.Http;
using Dialogue.Logic.Data.UnitOfWork;
using Dialogue.Logic.Data.Context;
using Dialogue.Logic.Constants;
using UmderlakareUmbCms.Business.Entities.ViewModel;

namespace UmderlakareUmbCms.Business.Services
{
    public class PostService : IPostsService
    {
        private  Dialogue.Logic.Services.PostService _postService;
        TopicService _topicService = new TopicService(new Dialogue.Logic.Services.TopicService());
        MemberService _memberService = new MemberService(new Dialogue.Logic.Services.MemberService());


        Dialogue.Logic.Services.MemberService _memberServ = new Dialogue.Logic.Services.MemberService();
        Dialogue.Logic.Services.CategoryService _catServ = new Dialogue.Logic.Services.CategoryService();
        Dialogue.Logic.Services.PermissionService _permissionService = new Dialogue.Logic.Services.PermissionService();
        Dialogue.Logic.Services.TopicService _topicServ = new Dialogue.Logic.Services.TopicService();


        public PostService(Dialogue.Logic.Services.PostService postService)
        {
            _postService = postService;
            
        }

        //Klar
        #region Get All Posts Request

        public IEnumerable<Post> GetAllPosts()
        {
            var topics = _topicService.GetAllTopics();
            List<Post> listOfPostsInTopic = new List<Post>();
            foreach (var topic in topics)
            {

                foreach (var post in topic.Posts)
                {
                    var po = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, post.UserName);
                    listOfPostsInTopic.Add(po);
                }


            }
            return listOfPostsInTopic.ToList();

        }

        #endregion

        //Klar
        #region Get Post By Id

        public Post GetPostById(Guid id)
        {
            var posts = _postService.Get(id);
            var member = _memberService.GetMemberById(posts.MemberId);
            var topic = _topicService.GetTopicById(posts.Topic.Id);
            return new Post(posts.Id, posts.MemberId, posts.PostContent, posts.DateCreated, posts.Topic.Id, member.UserName);

        }

        #endregion

        //Klar
        #region Get Post By memberId Request

        public List<Post> GetPostByMemberId(int memberId)
        {
            
            var posts = _postService.GetByMember(memberId);
            List<Post> postList = new List<Post>();

            foreach (var ps in posts)
            {
                var member = _memberService.GetMemberById(ps.MemberId);
                var customPost = new Post(ps.Id, ps.MemberId, ps.PostContent, ps.DateCreated, ps.Topic.Id, member.UserName );
                postList.Add(customPost);
                
            }

            return postList;
        }

        #endregion

        //Klar
        #region Get Paged Posts By TopicId

        public IPostPaging GetPostsByTopicId(Guid topicId, int pageIndex, int pageSize, int amountToTake, PostOrderBy order)
        {
            var posts = _postService.GetPagedPostsByTopic(pageIndex, pageSize, amountToTake, topicId, order);
            var hasMore = PagingHelper.HasMore(pageIndex, amountToTake, pageSize);
            var results = new PostPaging(hasMore, posts.TotalCount, posts);

            return results;
        }

        #endregion

        //Klar
        #region Delete
        // Delete post ska inte kunna deleta topicstarter
        public void Delete(Guid id)
        {

            bool isTopicStarter;
            Dialogue.Logic.Models.Topic topic;

            var UnitOfWorkManager = new UnitOfWorkManager(ContextPerRequest.Db);
            using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
            {
                var post = _postService.Get(id);
                
                isTopicStarter = post.IsTopicStarter;

                topic = post.Topic;
                var category = _catServ.Get(topic.CategoryId);
                var member = _memberServ.Get(post.MemberId);

                var permission = _permissionService.GetPermissions(category, member.Groups.FirstOrDefault());

                if (post.MemberId == member.Id || permission[AppConstants.PermissionModerate].IsTicked)
                {
                    var postUser = post.Member;

                    if(isTopicStarter == false)
                    {
                        var deletePost = _postService.Delete(post);
                        unitOfWork.SaveChanges();

                        try
                        {
                            unitOfWork.Commit();
                        }
                        catch (Exception)
                        {
                            unitOfWork.Rollback();
                            throw new Exception(Lang("Errors.GenericMessage"));
                        }
                    }
                   
                 

                }
            }

        }

        private string Lang(string v)
        {
            return "Not Deleted";
        }




        #endregion

        //Klar
        #region update Post
        public void EditPost(EditPostViewModel evm)
        {
            var UnitOfWorkManager = new UnitOfWorkManager(ContextPerRequest.Db);
            using (var unitOfWork = UnitOfWorkManager.NewUnitOfWork())
            {
                var post = _postService.Get(evm.Id);

                var topic = post.Topic;
                var category = _catServ.Get(topic.CategoryId);
                var member = _memberServ.Get(post.MemberId);
                var permission = _permissionService.GetPermissions(category, member.Groups.FirstOrDefault());

                if (post.MemberId == member.Id || permission[AppConstants.PermissionModerate].IsTicked)
                {
                    post.PostContent = evm.PostContent;
                    post.DateEdited = DateTime.UtcNow;

                    if (post.IsTopicStarter)
                    {
                        if (topic.CategoryId != evm.CategoryId)
                        {
                            var cat = _catServ.Get(evm.CategoryId);
                            topic.Category = cat;
                        }
                    }

                    try
                    {
                        unitOfWork.Commit();

                    }
                    catch (Exception)
                    {
                        unitOfWork.Rollback();

                    }

                }
            }
        }




        #endregion

        //Klar
        #region Create New Post

        public void AddPost(CreatePostViewModel vm)
        {
            Dialogue.Logic.Services.TopicService topServ = new Dialogue.Logic.Services.TopicService();
            Dialogue.Logic.Services.CategoryService catServ = new Dialogue.Logic.Services.CategoryService();
            Dialogue.Logic.Services.MemberService memberServ = new Dialogue.Logic.Services.MemberService();
            Dialogue.Logic.Services.PermissionService _permissionService = new Dialogue.Logic.Services.PermissionService();

            var topic = topServ.Get(new Guid(vm.TopicId));
            var category = catServ.Get(topic.CategoryId);
            topic.MemberId = vm.MemberId;
            var member = memberServ.Get(topic.MemberId);

            PermissionSet permissions = _permissionService.GetPermissions(category, member.Groups.FirstOrDefault());

            _postService.AddNewPost(vm.PostContent, topic, member, out permissions);

        }



        #endregion

    }

}