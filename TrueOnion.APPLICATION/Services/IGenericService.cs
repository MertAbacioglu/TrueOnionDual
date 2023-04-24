using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.DOMAIN.Entities;

namespace TrueOnion.APPLICATION.Services
{
    public interface IGenericService<T> where T : BaseEntity

    {

        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(IEnumerable<T> entities);
        void Remove(Guid id);
        void RemoveRange(IEnumerable<T> entities);
        Task<T> Update(T entity);


    }
}
