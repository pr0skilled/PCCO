using System.Linq.Expressions;

namespace PCCO.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        void Delete(TEntity item);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll(int page, int pageCount);
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate, string include);
        Task<TEntity> GetAsync<TKey>(TKey id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity item);
    }
}
