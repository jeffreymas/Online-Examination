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
    public class SectionsController : BaseController<Section, SectionRepository>
    {
        readonly SectionRepository _sectionRepository;
        readonly MyContext _context;
        public SectionsController(MyContext context, SectionRepository sectionRepository) : base(sectionRepository)
        {
            _context = context;
            _sectionRepository = sectionRepository;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Update(string id, Section entity)
        {
            var getId = await _sectionRepository.GetById(id);
            getId.Name = entity.Name;
            var data = await _sectionRepository.Update(getId);
            if (data.Equals(null))
            {
                return BadRequest("Something Wrong! Please check again");
            }
            return data;
        }
    }
}