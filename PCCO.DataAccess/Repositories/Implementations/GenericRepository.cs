using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PCCO.DataAccess.Repositories.Interfaces;

namespace PCCO.DataAccess.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PCCOContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(PCCOContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Delete(TEntity item)
        {
            if (_context.Entry(item).State == EntityState.Detached)
            {
                _dbSet.Attach(item);
            }
            _dbSet.Remove(item);
        }

        public TEntity GetById(int id)
        {
            var x = new Microsoft.EntityFrameworkCore.ChangeTracking.ValueComparer<string[]>(
                (x, y) => x.Length > y.Length,
                x => x.Length * 5);
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll(int page, int pageCount)
        {
            var pageSize = (page - 1) * pageCount;

            return _dbSet.Skip(pageSize).Take(pageCount);
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, string include)
        {
            return GetBy(predicate).Include(include);
        }

        public async Task<TEntity> GetAsync<TKey>(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public void Update(TEntity item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
