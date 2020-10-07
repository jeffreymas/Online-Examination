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
    public class ResultController : BaseController<Examination, ExaminationRepository>
    {
        private ExaminationRepository _repo;
        readonly MyContext _context;
        public ResultController(ExaminationRepository repo , MyContext myconn) : base(repo)
        {
            _repo = repo;
            _context = myconn;
        }
        [HttpGet("emp/{Id}")]
        public IActionResult GetByUserId(string Id)
        {
            if (Id == null)

            {
                return BadRequest("Id is null");
            }
            else
            {
                var score = _repo.GetByUser(Id);
                foreach (var item in score)
                {
                    //if (item.Score == 0)
                    //{
                        var result = setScore(item.Id);
                    //}
                    
                }
                
                if (score == null)
                {
                    return BadRequest("Data Not Found");
                }
                else
                {
                    return Ok(score);
                }
            }
        }

        public async Task<IActionResult> setScore(string id)
        {
            var examination = _context.Examinations.FirstOrDefault(x => x.Id == id);
            var listAnswer = _context.Answer.Where(x => x.ExamId == examination.Id).ToList();
            int count = 0;
            foreach (var item in listAnswer)
            {
                if (item.Status == true)
                {
                    count = count + 5;
                }
            }
            examination.Score = count;
            var data = await _repo.Update(examination);
            return  Ok();
        }
    }

}

