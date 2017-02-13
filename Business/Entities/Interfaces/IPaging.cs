using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmderlakareUmbCms.Business.Entities.Interfaces
{
    public interface IPaging
    {
        bool HasMore { get; }
        int TotalMatching { get; }

    }
}
