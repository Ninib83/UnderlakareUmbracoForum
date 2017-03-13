using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.ViewModel;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface IPostsService
    {
        List<Post> GetPostByMemberId(int memberId);
        IPostPaging GetPostsByTopicId(Guid TopicId, int page, int pageSize, int amountToTake, Dialogue.Logic.Models.PostOrderBy order);
        IEnumerable<Post> GetAllPosts();

        Post GetPostById(Guid id);

        void Delete(Guid id);

        void EditPost(EditPostViewModel evm);

        void AddPost(CreatePostViewModel vm);


    }
}