using ExamOnline.Context;
using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExamOnline.Repositories.Data
{
    public class SectionRepository : GeneralRepo<Section, MyContext>
    {
        private MyContext _context;
        public SectionRepository(MyContext context) : base(context)
        {
            _context = context;
        }
    }
}
