using ExamOnline.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("tb_t_answer")]
    public class Answer : BaseModel
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey ("Question")]
        public string QuestionId { get; set; }
        public Question Question { get; set; }

        public string Answers { get; set; }
        public bool Status { get; set; }
        public bool isDelete { get; set; }

        [ForeignKey("Examination")]
        public string ExamId { get; set; }
        public Examination Examination { get; set; }
    }
}
