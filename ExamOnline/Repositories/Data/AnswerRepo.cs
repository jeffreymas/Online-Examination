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
    public class AnswerRepo : GeneralRepo<Answer, MyContext>
    {
        readonly MyContext _context;
        IConfiguration _configuration;
        public AnswerRepo(MyContext context, IConfiguration config) : base(context)
        {
            _context = context;
            _configuration = config;
        }

        public override async Task<List<Answer>> GetAll()
        {
            List<Answer> answerList = null;
            try
            {
                answerList = await _context.Answer.Include("Question").Where(x => x.isDelete == false).ToListAsync();
                if (answerList.Count == 0)
                {
                    return null;
                }
                return answerList;
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
            return answerList;
        }
        public override async Task<Answer> GetById(string Id)
        {
            var data = await _context.Answer.Include("Question").SingleOrDefaultAsync(x => x.Id == Id && x.isDelete == false);
            if (!data.Equals(0))
            {
                return data;
            }
            return null;
        }
    }
}
