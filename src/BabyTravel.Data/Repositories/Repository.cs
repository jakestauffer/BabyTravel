using BabyTravel.Data.Contexts;
using BabyTravel.Data.Models;
using BabyTravel.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly BabyTravelDbContext _context;

        public Repository(BabyTravelDbContext context)
        {
            _context = context;
        }

        private DbSet<T> _table => _context.Set<T>();

        protected IQueryable<T> Entity => _table.AsQueryable();

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> query) => Entity.FirstOrDefaultAsync(query);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _table.Update(entity);
            await SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T T)
        {
            _table.Remove(T);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                return;
            }

            await DeleteAsync(entity);
        }

        private Task SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
