using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UmderlakareUmbCms.Business.Entities
{
    public class ApiResponse
    {
        public ApiResponse(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public int Code { get; }
        public object Message { get; }
    }
}