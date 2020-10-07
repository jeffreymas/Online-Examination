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
    public class QuestionsController : BaseController<Question, QuestionRepo>
    {
        readonly QuestionRepo _questionRepo;
        readonly MyContext _context;
        public QuestionsController(QuestionRepo queestionRepo, MyContext myContext) : base(queestionRepo)
        {
            _questionRepo = queestionRepo;
            _context = myContext;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(string id, Question entity)
        {
            var getId = await _questionRepo.GetById(id);
            getId.Questions = entity.Questions;
            getId.OptionA = entity.OptionA;
            getId.OptionB = entity.OptionB;
            getId.OptionC = entity.OptionC;
            getId.OptionD = entity.OptionD;
            getId.OptionE = entity.OptionE;
            getId.Key = entity.Key;

            var data = await _questionRepo.Update(getId);
            if (data.Equals(null))
            {
                return BadRequest("Update Failed");
            }
            return data;
        }

        [HttpGet]
        [Route("loadquestion/{id}")]
        public async Task<ActionResult> LoadSoal(string id)
        {
            var examination = await _context.Question.Include("Section").FirstOrDefaultAsync(x=> x.Id == id);
            return Ok(examination);
        }
    }
}