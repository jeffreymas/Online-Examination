using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Base;
using ExamOnline.Context;
using ExamOnline.Models;
using ExamOnline.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : BaseController<Notifications, NotifRepo>
    {
        private readonly NotifRepo _repository;
        readonly MyContext _context;
        public NotificationsController(NotifRepo repository, MyContext myContext) : base(repository)
        {
            _repository = repository;
            _context = myContext;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(string id, Notifications entity)
        {
            var getId = await _repository.GetById(id);
            if (entity.EmployeeId == null)
            {
                getId.Message = entity.Message;
            }
            else
            {
                getId.CreatedDate = entity.CreatedDate;
                getId.Message = entity.Message;
                getId.EmployeeId = entity.EmployeeId;
            }
            var data = await _repository.Update(getId);
            if (data.Equals(null))
            {
                return BadRequest("Something Wrong! Please check again");
            }
            return data;
        }

        [HttpGet]
        [Route("notif/{id}")]
        public async Task<ActionResult> Getnotife(string id)
        {
            var data = await _context.Notifications.FirstOrDefaultAsync(x => x.EmployeeId == id && x.isDelete == false);
            if (!data.Equals(0))
            {
                return Ok(data);
            }
            return null;
        }
    }
}