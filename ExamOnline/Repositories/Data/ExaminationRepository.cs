using ExamOnline.Base;
using ExamOnline.Context;
using ExamOnline.Controllers;
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
    public class ExaminationRepository : GeneralRepo<Examination, MyContext>
    {
        readonly MyContext _context;
        IConfiguration _configuration;
        RandomDigit randDig = new RandomDigit();
        public ExaminationRepository(MyContext context, IConfiguration config) : base(context)
        {
            _context = context;
            _configuration = config;
        }


        public override async Task<List<Examination>> GetAll()
        {
            var data = await _context.Examinations.Include("Subjects").Where(D => D.isDelete == false).ToListAsync();
            return data;
        }

        public override async Task<int> Create(Examination entity)
        {
            entity.isDelete = false;
            await _context.Set<Examination>().AddAsync(entity);
            var createdItem = await _context.SaveChangesAsync();
            var list = _context.Question.Where(x => x.SubjectId == entity.SubjectId && x.isDelete == false).ToArray();
            var eof = list.Length;
            string[] qid = new string[10];
            bool cek = false;
            for (int i = 0; i < 10; i++)
            {
                var number = randDig.GenerateRandom();
                var number2 = Convert.ToInt32(number);
                if (number2 < eof)
                {
                    var question = list[number2];
                    for (int j = 0; j < qid.Length; j++)
                    {
                        if (qid[j] != question.Id)
                        {
                            cek = true;
                        }else if (qid[j] == question.Id)
                        {
                            cek = false;
                            break;
                        }
                    }
                    if (cek == true)
                    {
                        var answers = new Answer();
                        answers.ExamId = entity.Id;
                        answers.Answers = null;
                        answers.isDelete = false;
                        answers.Status = false;
                        answers.QuestionId = question.Id;
                        await _context.Answer.AddAsync(answers);
                        _context.SaveChanges();
                        qid[i] = question.Id;
                        var cc = qid[i];
                        cek = false;
                    }
                    else
                    {
                        i = i - 1;
                    }
                    
                }
                else
                {
                    i = i - 1;
                }

            }
            return createdItem;
        }

        public class RandomDigit
        {
            private Random _random = new Random();
            public string GenerateRandom()
            {
                return _random.Next(0, 10).ToString("D2");
            }
        }

        public List<Examination> GetByUser(string Id)
        {
            var item = _context.Examinations.Include("Subjects").Where(x => x.EmployeeId == Id).ToList();
            
            if(item == null)
            {
                return null;
            }
            else
            {
                return item;
            }
        }

        
    }
}
