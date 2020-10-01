using ExamOnline.Context;
using ExamOnline.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<EventDetails>> GetEventId (string Id)
        {
            List<EventDetails> item = null;

            item = await _context.EventDetails.Where(x => x.eventsId == Id && x.isDelete == false).ToListAsync();

            if(item == null)
            {
                return null;
            }
            return item;
        }

        public int DeleteUser(EventDetails eventDetails)
        {
            var item = _context.EventDetails.Where(x => x.eventsId == eventDetails.eventsId && x.EmployeeId == eventDetails.EmployeeId && x.isDelete == false).SingleOrDefault();

            if(item == null)
            {
                return 0;
            }
            else
            {
                item.isDelete = true;
                _context.Entry(item).State = EntityState.Modified;
                return _context.SaveChanges();
            }
        }
    }
}
