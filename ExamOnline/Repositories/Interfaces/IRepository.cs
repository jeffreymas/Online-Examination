using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamOnline.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string Id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(string Id);
    }
}
