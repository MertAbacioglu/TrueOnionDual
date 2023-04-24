using System.Linq.Expressions;
using TrueOnion.APPLICATION.UnitOfWork;
using TrueOnion.DOMAIN.Entities;

namespace TrueOnion.APPLICATION.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<T> Update(T entity);
        public Task<IQueryable<T>> GetAllAsIQueryable();

    }
}