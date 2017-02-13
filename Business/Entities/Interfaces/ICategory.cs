using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public class ICategory
    {
        int Id { get; }

        string CategoryName { get; }
        //string Description { get; }
        DateTime? CreateDate { get; }



    }
}