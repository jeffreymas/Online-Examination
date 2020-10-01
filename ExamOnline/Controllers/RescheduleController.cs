using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExamOnline.Context;
using ExamOnline.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RescheduleController : ControllerBase
    {
        private readonly MyContext _context;


        public RescheduleController(MyContext myContext)
        {
            _context = myContext;
        }

        [HttpGet]
        public async Task<List<Examination>> GetAll()
        {
            List<Examination> list = new List<Examination>();

            var getData = await _context.Examinations.Include("Subjects").Where(Q => Q.RescheduleDate != null && Q.isDelete == false).ToListAsync();

            if (getData.Count == 0)
            {
                return null;
            }
            foreach (var item in getData)
            {
                var user = new Examination()
                {
                    Id = item.Id,
                    EmployeeId = item.EmployeeId,
                    SubjectId = item.Subjects.Name,
                    CreatedDate = item.CreatedDate,
                    RescheduleDate = item.RescheduleDate

                };
                list.Add(user);
            }
            return list;
        }
        [HttpPost]
        [Route("Approve")]
        public IActionResult Approve(Examination examination)
        {
            if (ModelState.IsValid)
            {
                var jobsid = _context.Examinations.Include("Subjects").Where(r => r.Id == examination.Id).FirstOrDefault();
                var nottif = _context.Notifications.FirstOrDefault(x => x.EmployeeId == examination.EmployeeId);

                var newdate = jobsid.RescheduleDate;
                jobsid.CreatedDate = newdate.Value;
                jobsid.RescheduleDate = null;

                if(nottif == null)
                {
                    var notif = new Notifications();
                    notif.EmployeeId = jobsid.EmployeeId;
                    notif.CreatedDate = DateTimeOffset.Now;
                    notif.Message = "Your Reschedule has approved";

                    _context.Notifications.Add(notif);
                }
                else
                {
                    nottif.Message = "Your Reschedule has approved";
                }
                
                _context.SaveChanges();
                return Ok("Successfully Sent");
            }
            return BadRequest("Not Successfully");
        }

        [HttpPost]
        [Route("Reject")]
        public IActionResult Reject(Examination examination)
        {
            if (ModelState.IsValid)
            {
                var jobsid = _context.Examinations.Include("Subjects").Where(r => r.Id == examination.Id).FirstOrDefault();
                var nottif = _context.Notifications.FirstOrDefault(x => x.EmployeeId == examination.EmployeeId);

                jobsid.RescheduleDate = null;

                if (nottif == null)
                {
                    var notif = new Notifications();
                    notif.EmployeeId = jobsid.EmployeeId;
                    notif.CreatedDate = DateTimeOffset.Now;
                    notif.Message = "Your Reschedule has Rejected";

                    _context.Notifications.Add(notif);
                }
                else
                {
                    nottif.Message = "Your Reschedule has Rejected";
                }
                _context.SaveChanges();
                return Ok("Successfully Sent");
            }
            return BadRequest("Not Successfully");
        }

    }
}