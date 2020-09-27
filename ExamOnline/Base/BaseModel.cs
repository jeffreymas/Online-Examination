using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Base
{
    public interface BaseModel
    {
        string Id { get; set; }
        bool isDelete { get; set; }
    }
}
