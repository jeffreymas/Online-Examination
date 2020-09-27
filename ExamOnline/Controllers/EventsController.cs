using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamOnline.Base;
using ExamOnline.Models;
using ExamOnline.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : BaseController<Events, EventsRepo>
    {
        private EventsRepo _repo;

        public EventsController(EventsRepo eventsRepo) : base(eventsRepo)
        {
            this._repo = eventsRepo;
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> Update(string Id, Events events)
        {
            Events item = await _repo.GetById(Id);
            item.Name = events.Name;
            int updatedItem = await _repo.Update(item);

            if (updatedItem > 0)
            {
                return Ok("Data is updated");
            }
            return BadRequest("Update data is failed");

        }
    }
}