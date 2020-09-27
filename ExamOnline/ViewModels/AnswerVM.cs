using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.ViewModels
{
    public class AnswerVM
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string QuestionKey { get; set; }
        public string Answers { get; set; }
        public bool Status { get; set; }
        public bool isDelete { get; set; }
    }
}
