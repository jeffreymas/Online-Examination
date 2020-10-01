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
    public class ExaminationsController : BaseController<Examination, ExaminationRepository>
    {
        readonly ExaminationRepository _repository;
        readonly MyContext _context;
        public ExaminationsController(ExaminationRepository repository, MyContext myContext) : base(repository)
        {
            _repository = repository;
            _context = myContext;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(string id, Examination entity)
        {
            var getId = await _repository.GetById(id);
            if (entity.ExpiredDate != null && getId.ExpiredDate == null)
            {
                getId.ExpiredDate = entity.ExpiredDate;
            }
            else if (entity.EmployeeId == null )
            {
                getId.RescheduleDate = entity.RescheduleDate;
            }
            else
            {
                getId.CreatedDate = entity.CreatedDate;
                getId.Score = entity.Score;
                getId.EmployeeId = entity.EmployeeId;
                getId.SubjectId = entity.SubjectId;
            }
            var data = await _repository.Update(getId);
            if (data.Equals(null))
            {
                return BadRequest("Something Wrong! Please check again");
            }
            return data;
        }

        public void setScore(string id)
        {
            var examination = _context.Examinations.FirstOrDefault(x => x.Id == id);
            var listAnswer = _context.Answer.Where(x => x.ExamId == id).ToList();
            int count = 0;
            foreach (var item in listAnswer)
            {
                if (item.Status == true)
                {
                    count = count + 10;
                }
            }
            examination.Score = count;
            var data = _repository.Update(examination);
        }
        [HttpGet]
        [Route("details/{id}")]
        public async Task<ActionResult> GetUserById(string id)
        {
            var examination = await _context.Examinations.Include("Subjects").FirstOrDefaultAsync(x => x.EmployeeId == id && x.isDelete == false);
            return Ok(examination);
        }

        [HttpGet]
        [Route("loadsoal/{id}")]
        public async Task<ActionResult> LoadSoal(string id)
        {
            var examination = await _context.Answer.Include("Question").Include("Examination").Where(x => x.ExamId == id).ToListAsync();
            return Ok(examination);
        }
    }
}