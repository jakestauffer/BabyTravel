using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Repositories.Abstractions
{
    public interface IRepository<T>
        where T : class
    {
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> query);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task DeleteByIdAsync(int id);
        public Task DeleteAsync(T entity);
    }
}
