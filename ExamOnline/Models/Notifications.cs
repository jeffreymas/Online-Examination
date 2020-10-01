using ExamOnline.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    public class Notifications : BaseModel
    {
        public string Id { get; set; }
        public string EmployeeId { set; get; }
        public string Message { set; get; }
        public DateTimeOffset CreatedDate { set; get; }
        public DateTimeOffset RequestedDate { set; get; }
        public bool isDelete { get; set; }
    }
}
