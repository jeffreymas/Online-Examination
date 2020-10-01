using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using ExamOnline.Base;
using ExamOnline.Models;
using ExamOnline.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : BaseController<Subjects, SubjectsRepo>
    {
        private SubjectsRepo _repo;

        public SubjectsController(SubjectsRepo repo) : base (repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public override async Task<ActionResult<Subjects>> Post(Subjects entity)
        {
            if(entity.Name == null)
            {
                return BadRequest("Data empty");
            }
            else
            {
                return await base.Post(entity);             //calling super method using base
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Update (string Id, Subjects subjects)
        {
            Subjects subjects1 = await _repo.GetById(Id);
            subjects1.Name = subjects.Name;
            int updatedItem = await _repo.Update(subjects1);

            if(updatedItem > 0)
            {
                return Ok("Data is updated");
            }
            return BadRequest("Update data is failed");
        }
    }
}
