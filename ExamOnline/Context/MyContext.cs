using ExamOnline.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventDetails> EventDetails { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
    }
}
