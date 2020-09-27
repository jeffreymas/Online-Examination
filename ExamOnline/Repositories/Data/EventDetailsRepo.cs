using ExamOnline.Context;
using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories.Data
{
    public class EventDetailsRepo : GeneralRepo<EventDetails, MyContext>
    {
        private MyContext _context;
        public EventDetailsRepo(MyContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<EventDetails>> GetEventId(string Id)
        {
            List<EventDetails> item = null;
            item = await _context.EventDetails.Where(x => x.eventsId == Id).ToListAsync();
            if (item == null)
            {
                return null;
            }
            return item;
        }
    }
}
