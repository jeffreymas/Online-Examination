using ExamOnline.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("tb_m_events")]
    public class Events : BaseModel
    {
        public string Id { get; set; }
        public string Name { set; get; }
        public DateTimeOffset StartDate { set; get; }
        public DateTimeOffset EndDate { set; get; }
        public bool isDelete { get; set; }
    }
}
