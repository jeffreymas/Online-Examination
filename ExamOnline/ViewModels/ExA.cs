using ExamOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.ViewModels
{
    public class ExA
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public string Answers { get; set; }
        public bool Status { get; set; }
        public bool isDelete { get; set; }
        public string ExamId { get; set; }
        public Examination Examination { get; set; }
        public int QuestionNummber { get; set; }
        public string Section { get; set; }
    }
}
