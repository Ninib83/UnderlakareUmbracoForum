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

        // Klar
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
        //public List<Post> GetPostsByTopicId(Guid topicId)
        //{
        //    var posts = _postService.GetPagedPostsByTopic();
        //}

        #endregion

        //Skapa Logik
        #region Delete
        #endregion

        //Skapa Logik
        #region update Post
        #endregion

        //Skapa Logik
        #region Create New Post

        public void AddPost(CreatePostViewModel vm)
        {
            Dialogue.Logic.Models.Post post = new Dialogue.Logic.Models.Post();
            Dialogue.Logic.Models.Topic topic = new Dialogue.Logic.Models.Topic();

            post.PostContent = vm.PostContent;
            post.MemberId = vm.MemberId;

           
                topic.Id = new Guid(vm.TopicId);
                _postService.Add(post);
            

            
        }

        #endregion

    }

}