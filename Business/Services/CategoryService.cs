using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dialogue.Logic.Services;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Services.Interfaces;
using UmderlakareUmbCms.Business.Entities;
using Umbraco.Core.Models;
using Umbraco.Web.Security;
using Umbraco.Web;

namespace UmderlakareUmbCms.Business.Services
{
    public class CategoryService : ICategorysService
    {

        private readonly Dialogue.Logic.Services.CategoryService _categoryService;
        private  Dialogue.Logic.Services.TopicService _topicService = new Dialogue.Logic.Services.TopicService();
        private Dialogue.Logic.Services.PostService _postService = new Dialogue.Logic.Services.PostService();

        MemberService _memberService = new MemberService(new Dialogue.Logic.Services.MemberService());

        public CategoryService(Dialogue.Logic.Services.CategoryService categoryService)
        {
            _categoryService = categoryService;
            
            
        }

        // Klart
        #region Get All Main and Sub Categories Request

        public IEnumerable<MainCategory> GetAllMainAndSubCategories()
        {
            List<MainCategory> listOfCategories = new List<MainCategory>();
            
            var categories = _categoryService.GetAllMainCategories();
           

            
            foreach (var cat in categories)
            {
               
                List<SubCategory> listOfSubCategories = new List<SubCategory>();

                

                foreach (var sub in cat.Children)
                {
                    var allTopics = _topicService.GetAll().ToList();
                    List<Topic> listOfTopicsInCategory = new List<Topic>();
                    List<Post> listOfPostsInCategory = new List<Post>();
                    
                    foreach (var topic in allTopics)
                    {
                        List<Post> listOfPostsInTopic = new List<Post>();

                        if (sub.Id == topic.CategoryId)
                        {
                            foreach(var post in topic.Posts)
                            {
                               
                                var postInTopi = new Post(post.Id, post.MemberId, post.PostContent,post.DateCreated, topic.Id, topic.Name);
                                listOfPostsInTopic.Add(postInTopi);
                            }


                            var memberInTopic = _memberService.GetMemberById(topic.MemberId);
                            var topicInCat = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPostsInTopic, memberInTopic.UserName, memberInTopic.DateCreated);
                            listOfTopicsInCategory.Add(topicInCat);    

                        }

                       

                    }
                    LastTopic latestTopic = null;
                    LastPost latestPost = null;
                    
                    foreach (var t in listOfTopicsInCategory)
                    {
                        if(t.CreateDate <= DateTime.Now)
                        {
                            latestTopic = new LastTopic(t.Id, t.Name, t.CreateDate);
                        }

                        foreach(var post in t.Posts)
                        {
                            if(post.DateCreated <= DateTime.Now)
                            {
                                var member = _memberService.GetMemberById(post.MemberId);
                                latestPost = new LastPost(post.Id, post.DateCreated, member.UserName);
                            }

                            var postInTopic = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, t.Id, post.UserName);
                            listOfPostsInCategory.Add(postInTopic);
                        }
                    }


                    var subCat = new SubCategory(sub.Id, sub.Name, listOfTopicsInCategory.Count, listOfPostsInCategory.Count, latestTopic, latestPost);
                    listOfSubCategories.Add(subCat);

                }

                
                var mainCat = new MainCategory(cat.Id, cat.Name, listOfSubCategories);
                listOfCategories.Add(mainCat);
            }

            return listOfCategories;
        }

        #endregion

        // Klart
        #region Get All Sub Categories Request

        public IEnumerable<SubCategory> GetAllSubCategories()
        {


            var categories = _categoryService.GetAll();
            List<SubCategory> listOfSubCategories = new List<SubCategory>();

            foreach (var cat in categories)
            {

                foreach (var sub in cat.Children)
                {


                    var allTopics = _topicService.GetAll().ToList();
                    List<Topic> listOfTopicsInCategory = new List<Topic>();
                    List<Post> listOfPostInSubCategory = new List<Post>();

                    foreach (var topic in allTopics)
                    {
                        List<Post> listOfPostsInTopic = new List<Post>();

                        if (sub.Id == topic.CategoryId)
                        {


                            foreach (var post in topic.Posts)
                            {
                                var postInTopi = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, topic.Name);
                                listOfPostsInTopic.Add(postInTopi);
                            }

                            var memberInTopic = _memberService.GetMemberById(topic.MemberId);
                            var topicInCat = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPostsInTopic, memberInTopic.UserName, memberInTopic.DateCreated);
                            listOfTopicsInCategory.Add(topicInCat);

                        }
                    }

                    LastPost latestPost = null;
                    LastTopic latestTopic = null;
                    foreach (var t in listOfTopicsInCategory)
                    {
                        if (t.CreateDate <= DateTime.Now)
                        {
                            latestTopic = new LastTopic(t.Id, t.Name, t.CreateDate);
                        }

                        foreach (var post in t.Posts)
                        {
                            if (post.DateCreated <= DateTime.Now)
                            {
                                var member = _memberService.GetMemberById(post.MemberId);
                                latestPost = new LastPost(post.Id, post.DateCreated, member.UserName);
                            }

                            var postInSubCategory = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, t.Id, t.Name);
                            listOfPostInSubCategory.Add(postInSubCategory);
                        }
                    }

                    var subCat = new SubCategory(sub.Id, sub.Name, listOfTopicsInCategory.Count, listOfPostInSubCategory.Count, latestTopic, latestPost);
                    listOfSubCategories.Add(subCat);
                }


            }
            return listOfSubCategories;

        }



        #endregion

        // Klart
        #region Get Main And Sub Category by MainCategoryId Request
        public IMainCategory GetMainCategoryById(int id)
        {
            List<SubCategory> listOfSubCategories = new List<SubCategory>();
            var categories = _categoryService.Get(id);

            foreach (var cat in categories.Children)
            {
                
                var allTopics = _topicService.GetAll().ToList();
                List<Topic> listOfTopicsInCategory = new List<Topic>();
                List<Post> listOfPostsInCategory = new List<Post>();

                foreach (var topic in allTopics)
                {
                    List<Post> listOfPostsInTopic = new List<Post>();

                    if (cat.Id == topic.CategoryId)
                    {
                        foreach (var post in topic.Posts)
                        {

                            var postInTopi = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, topic.Name);
                            listOfPostsInTopic.Add(postInTopi);
                        }


                        var memberInTopic = _memberService.GetMemberById(topic.MemberId);
                        var topicInCat = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPostsInTopic, memberInTopic.UserName, memberInTopic.DateCreated);
                        listOfTopicsInCategory.Add(topicInCat);

                    }

                }
                LastTopic latestTopic = null;
                LastPost latestPost = null;

                foreach (var t in listOfTopicsInCategory)
                {
                    if (t.CreateDate <= DateTime.Now)
                    {
                        latestTopic = new LastTopic(t.Id, t.Name, t.CreateDate);
                    }

                    foreach (var post in t.Posts)
                    {
                        if (post.DateCreated <= DateTime.Now)
                        {
                            var member = _memberService.GetMemberById(post.MemberId);
                            latestPost = new LastPost(post.Id, post.DateCreated, member.UserName);
                        }

                        var postInTopic = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, t.Id, post.UserName);
                        listOfPostsInCategory.Add(postInTopic);
                    }
                }


                var subCat = new SubCategory(cat.Id, cat.Name, listOfTopicsInCategory.Count, listOfPostsInCategory.Count, latestTopic, latestPost);
                listOfSubCategories.Add(subCat);


            }
            return new MainCategory(categories.Id, categories.Name, listOfSubCategories);
        }


        #endregion

        // Klart
        #region Get Sub Category By SubCategoryId Requset

        public IEnumerable<SubCategoriesId> GetSubCategoryById(int id)
        {
            List<Topic> listOfTopicsInCategory = new List<Topic>();
            var subCategories = _categoryService.Get(id);
            var alltopics = _topicService.GetAll().ToList();

            foreach (var topic in alltopics)
            {
                List<Post> listOfPostsInTopic = new List<Post>();

                foreach (var post in topic.Posts)
                {
                    var member = _memberService.GetMemberById(post.MemberId);
                    var postInTopic = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, member.UserName);
                    listOfPostsInTopic.Add(postInTopic);
                }
                var memberInTopic = _memberService.GetMemberById(topic.MemberId);
                var topicInSubCat = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPostsInTopic, memberInTopic.UserName, memberInTopic.DateCreated);
                listOfTopicsInCategory.Add(topicInSubCat);
            }

            yield return new SubCategoriesId(subCategories.Id, subCategories.Name, listOfTopicsInCategory);
        }



        //public SubCategoy GetSubCategoryById(int id)
        //{
        //    var subCategories = _categoryService.Get(id);

        //    List<SubCategory> listOfSubCategories = new List<SubCategory>();



        //            var allTopics = _topicService.GetAll().ToList();
        //            List<Topic> listOfTopicsInCategory = new List<Topic>();
        //            List<Post> listOfPostInSubCategory = new List<Post>();

        //            foreach (var topic in allTopics)
        //            {
        //                List<Post> listOfPostsInTopic = new List<Post>();



        //                    foreach (var post in topic.Posts)
        //                    {
        //                        var postInTopi = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, topic.Id, topic.Name);
        //                        listOfPostsInTopic.Add(postInTopi);
        //                    }

        //                    var topicInCat = new Topic(topic.Id, topic.MemberId, topic.CategoryId, topic.Views, topic.Name, topic.CreateDate, listOfPostsInTopic);
        //                    listOfTopicsInCategory.Add(topicInCat);


        //            }

        //            LastPost latestPost = null;
        //            LastTopic latestTopic = null;
        //            foreach (var t in listOfTopicsInCategory)
        //            {
        //                if (t.CreateDate <= DateTime.Now)
        //                {
        //                    latestTopic = new LastTopic(t.Id, t.Name, t.CreateDate);
        //                }

        //                foreach (var post in t.Posts)
        //                {
        //                    if (post.DateCreated <= DateTime.Now)
        //                    {
        //                        var member = _memberService.GetMemberById(post.MemberId);
        //                        latestPost = new LastPost(post.Id, post.DateCreated, member.UserName);
        //                    }

        //                    var postInSubCategory = new Post(post.Id, post.MemberId, post.PostContent, post.DateCreated, t.Id, t.Name);
        //                    listOfPostInSubCategory.Add(postInSubCategory);
        //                }
        //            }


        //            return new SubCategory(subCategories.Id, subCategories.Name, listOfTopicsInCategory.Count, listOfPostInSubCategory.Count, latestTopic, latestPost);
        //}


        #endregion

    }
}