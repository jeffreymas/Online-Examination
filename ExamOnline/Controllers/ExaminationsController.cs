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
            getId.RescheduleDate = entity.RescheduleDate;
            getId.Score = entity.Score;
            getId.EmployeeId = entity.EmployeeId;
            getId.SubjectId = entity.SubjectId;
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
                    count = count + 1;
                }
            }
            examination.Score = count / 10;
            _repository.Update(examination);
        }
    }
}