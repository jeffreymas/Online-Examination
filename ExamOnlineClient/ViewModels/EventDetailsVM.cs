using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnlineClient.ViewModels
{
    public class EventDetailsVM
    {
        public string Id { get; set; }
        public string eventsId { set; get; }
        public string EmployeeId { set; get; }
        public bool isDelete { get; set; }
    }
}
