using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnlineClient.ViewModels
{
    public class NotificationVM
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string message { get; set; }
        public DateTimeOffset createdDate { get; set; }
    }
}
