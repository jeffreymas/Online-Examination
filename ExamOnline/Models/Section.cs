using ExamOnline.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("tb_t_Section")]
    public class Section : BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool isDelete { get; set; }
    }
}
