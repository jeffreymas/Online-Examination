using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.ViewModels
{
    public class QuestionVM
    {
        public string Id { get; set; }
        public string Questions { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }
        public string Key { get; set; }
        public bool isDelete { get; set; }
        public string SubjectId { get; set; }
    }
}
