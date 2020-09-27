using ExamOnline.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("tb_m_question")]
    public class Question : BaseModel
    {
        [Key]
        public string Id { get; set; }
        public string Questions { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string OptionE { get; set; }
        public string Key { get; set; }
        public bool isDelete { get; set; }
        [ForeignKey("Subjects")]
        public string SubjectId { get; set; }
        public Subjects Subjects { get; set; }
    }
}
