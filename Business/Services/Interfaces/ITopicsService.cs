using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;
using System.Web.Http;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface ITopicsService
    {
        ITopic GetTopicById(Guid id);
        IList<Topic> GetAllTopicsByUser(int memberId);
        ITopicPaging GetRecentTopics(int page, int size);
        List<Topic> GetAllTopics();
        ITopicPaging GetTopicByCategoryId(int categoryId, int page, int pageSize);




        void Delete(Guid id);
        void AddTopi(CreateTopicViewModel vm);
        //Dialogue.Logic.Models.Topic GetByIdForDelete(Guid id);
    }

  
}
