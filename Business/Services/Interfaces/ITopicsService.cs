using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmderlakareUmbCms.Business.Entities;
using UmderlakareUmbCms.Business.Entities.Interfaces;

namespace UmderlakareUmbCms.Business.Services.Interfaces
{
    public interface ITopicsService
    {
        ITopic GetTopicById(Guid id);
        IList<Topic> GetAllTopicsByUser(int memberId);
        ITopicPaging GetRecentTopics(int page, int size);

    }

  
}
