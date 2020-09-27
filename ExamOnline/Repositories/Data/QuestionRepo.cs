using ExamOnline.Context;
using ExamOnline.Models;
using ExamOnline.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories.Data
{
    public class QuestionRepo : GeneralRepo<Question, MyContext>
    {
        readonly MyContext _context;
        IConfiguration _configuration;
        public QuestionRepo(MyContext context, IConfiguration config) : base(context)
        {
            _context = context;
            _configuration = config;
        }
        public override async Task<List<Question>> GetAll()
        {
            List<QuestionVM> list = new List<QuestionVM>();
            var data = await _context.Question.Include("Subjects").Where(x => x.isDelete == false).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            return data;
        }
        public override async Task<Question> GetById(string Id)
        {
            var data = await _context.Question.Include("Subjects").SingleOrDefaultAsync(x => x.Id == Id && x.isDelete == false);
            if (!data.Equals(0))
            {
                return data;
            }
            return null;
        }
    }
}
