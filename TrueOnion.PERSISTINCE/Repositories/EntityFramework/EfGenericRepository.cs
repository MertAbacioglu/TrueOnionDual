using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.UnitOfWork;
using TrueOnion.DOMAIN.Entities;
using TrueOnion.PERSISTINCE.Context;

namespace TrueOnion.PERSISTINCE.Repositories.EntityFramework
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly EFDbContext _appDbContext;
        protected readonly DbSet<T> _dbSet;
        private readonly IUnitOfWork _unitOfWork;
        public EfGenericRepository(EFDbContext appDbContext, IUnitOfWork unitOfWork = null)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<T>();
            _unitOfWork = unitOfWork;
        }

        public  async Task<T> GetByIdAsync(Guid id)
        {
            //T? result = await _dbSet.FindAsync(id);
            T? result =   _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
            

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _unitOfWork.SaveAsync();
            return entities;
        }

        public  void Remove(T entity)
        {
            _dbSet.Remove(entity);
             _unitOfWork.Save();

        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            _appDbContext.SaveChanges();
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            _appDbContext.SaveChanges();
            return entity;
        }

        public async Task<IQueryable<T>> GetAllAsIQueryable()
        {
            return  _dbSet.AsNoTracking();
        }
    }
}