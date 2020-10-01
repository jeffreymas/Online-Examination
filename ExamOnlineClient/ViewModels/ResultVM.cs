using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnlineClient.ViewModels
{
    public class ResultVM
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string subject { get; set; }
        public DateTimeOffset createDate { get; set; }
        public int score { get; set; }
    }
}
