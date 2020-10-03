using ExamOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnlineClient.ViewModels
{
    public class ExaminationVM
    {
        public string Id { get; set; }
        public bool isDelete { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? RescheduleDate { get; set; }
        public int Score { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string SubjectId { get; set; }
        public Subjects Subjects { get; set; }
    }
}
