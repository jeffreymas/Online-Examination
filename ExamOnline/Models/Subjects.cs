using ExamOnline.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("tb_m_subjects")]
    public class Subjects : BaseModel
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public bool isDelete { get; set; }
    }
}
