using ExamOnline.Context;
using ExamOnline.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories.Data
{
    public class ExaminationRepository : GeneralRepo<Examination, MyContext>
    {
        readonly MyContext _context;
        IConfiguration _configuration;
        public ExaminationRepository(MyContext context, IConfiguration config) : base(context)
        {
            _context = context;
            _configuration = config;
        }
    }
}
