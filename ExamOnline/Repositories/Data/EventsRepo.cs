using ExamOnline.Context;
using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories.Data
{
    public class EventsRepo : GeneralRepo<Events, MyContext>
    {
        private MyContext _context;
        
        public EventsRepo(MyContext context) : base (context)
        {
            this._context = context;
        }

       
    }
}
