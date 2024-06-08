using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChallengeN5Now.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        public readonly DbSet<T> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> Get(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }
        public virtual async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);

            return entity;
        }
        public virtual bool HasEmployeePermission(T entity)
        {
            var hep = HasEmployeePermission(entity);

            return hep;
        }

        public virtual T Update(T entity)
        {
            _context.Update(entity);

            return entity;
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
        }
    }
}
