using ExamOnline.Base;
using ExamOnline.Context;
using ExamOnline.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories
{
    public class GeneralRepo<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, BaseModel
        where TContext : MyContext
    {
        private MyContext _context;

        public GeneralRepo(MyContext context)
        {
            _context = context;
        }
        public async Task<int> Create(TEntity entity)
        {
            entity.isDelete = false;
            await _context.Set<TEntity>().AddAsync(entity);
            var createdItem = await _context.SaveChangesAsync();
            return createdItem;
        }

        public async Task<int> Delete(string Id)
        {
            var item = await GetById(Id);
            if (item == null)
            {
                return 0;
            }
            item.isDelete = true;
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var get = await _context.Set<TEntity>().Where(x=>x.isDelete == false).ToListAsync();

            if (!get.Count().Equals(0))
            {
                return get;
            }
            return null;
        }

        public virtual async Task<TEntity> GetById(string Id)
        {
            var item = await _context.Set<TEntity>().SingleOrDefaultAsync(x=> x.Id == Id && x.isDelete == false);
            if (item == null)
            {
                return null;
            }
            return item;
        }


        public async Task<int> Update(TEntity entity)
        {
            //entity.updateDate = DateTimeOffset.Now;
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
