using ExamOnline.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Models
{
    [Table("tb_t_event_details")]
    public class EventDetails : BaseModel
    {
        public string Id { get; set; }

        [ForeignKey("EventsId")]
        public string eventsId { set; get; }
        public virtual Events events { set; get; }
        public string EmployeeId { set; get; }
        public bool isDelete { get; set; }
    }
}
