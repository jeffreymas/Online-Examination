using ExamOnline.Context;
using ExamOnline.Models;
using Microsoft.AspNetCore.Identity.UI.Pages.Internal.Account;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories.Data
{
    public class NotifRepo : GeneralRepo<Notifications, MyContext>
    {
        private MyContext _context;
        public NotifRepo(MyContext context) : base(context)
        {
            _context = context;
        }


        public override async Task<List<Notifications>> GetAll()
        {
            List<Notifications> list = new List<Notifications>();
            var data = await _context.Notifications.Where(x => x.isDelete == false).ToListAsync();
            if (data.Count == 0)
            {
                return null;
            }
            return data;
        }
        public override async Task<Notifications> GetById(string Id)
        {
            var data = await _context.Notifications.SingleOrDefaultAsync(x => x.Id == Id && x.isDelete == false);
            if (!data.Equals(0))
            {
                return data;
            }
            return null;
        }
    }
}
