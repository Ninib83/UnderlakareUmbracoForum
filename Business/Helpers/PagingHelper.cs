using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Helpers
{
    public static class PagingHelper
    {
        public static bool HasMore(int page, int take, int size)
        {
            return (page * take) < size;
        }

    }
}