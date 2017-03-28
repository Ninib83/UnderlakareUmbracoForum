using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface SubCategoy
    {
        int Id { get; }
        string Name { get; }
        int TopicCount { get; }
        int PostCount { get; }
        LastTopic LastTopic { get; }       
        LastPost LastPost { get; }

    }
}