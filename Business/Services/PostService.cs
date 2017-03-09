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

namespace UmderlakareUmbCms.Business.Services
{
    public class PostService : IPostsService
    {
        private  Dialogue.Logic.Services.PostService _postService;
        TopicService _topicService = new TopicService(new Dialogue.Logic.Services.TopicService());
        MemberService _memberService = new MemberService(new Dialogue.Logic.Services.MemberService());

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

        // Skapa logik
        #region Get Paged Posts By TopicId
        
        //public IEnumerable<Post> GetPostsByTopicId(Guid TopicId)
        //{
        //    var posts = _postService.GetPagedPostsByTopic(TopicId);
        //}

        #endregion

        //Klar
        #region Delete


        public void Delete(Guid id)
        {

            var posts = _postService.GetAll();
            foreach (var post in posts)
            {
                if (posts != null && post.Id == id)
                {

                    _postService.Delete(post);

                }

            }


        }




        #endregion

        //Skapa Logik
        #region update Post

        public void Edit(Guid id, CreatePostViewModel vm)
        {
            var posts = _postService.Get(id);
            var member = _memberService.GetMemberById(posts.MemberId);
            var topic = _topicService.GetTopicById(posts.Topic.Id);
            var post = new Post(posts.Id, posts.MemberId, posts.PostContent, posts.DateCreated, posts.Topic.Id, member.UserName);


            Dialogue.Logic.Services.TopicService topServ = new Dialogue.Logic.Services.TopicService();
            Dialogue.Logic.Services.CategoryService catServ = new Dialogue.Logic.Services.CategoryService();
            Dialogue.Logic.Services.MemberService memberServ = new Dialogue.Logic.Services.MemberService();
            Dialogue.Logic.Services.PermissionService _permissionService = new Dialogue.Logic.Services.PermissionService();

            var top = topServ.Get(new Guid(vm.TopicId));

            var category = catServ.Get(topic.CategoryId);
            Dialogue.Logic.Models.Member user = new Dialogue.Logic.Models.Member();
            top.MemberId = vm.MemberId;
            var membr = memberServ.Get(topic.MemberId);

            Dialogue.Logic.Models.PermissionSet permissions = _permissionService.GetPermissions(category, membr.Groups.FirstOrDefault());

            _postService.AddNewPost(vm.PostContent, top, membr, out permissions);



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
            //Dialogue.Logic.Models.Member user = new Dialogue.Logic.Models.Member();
            topic.MemberId = vm.MemberId;
            var member = memberServ.Get(topic.MemberId);

            Dialogue.Logic.Models.PermissionSet permissions = _permissionService.GetPermissions(category, member.Groups.FirstOrDefault());

            _postService.AddNewPost(vm.PostContent, topic, member, out permissions);

        }

        #endregion

    }

}