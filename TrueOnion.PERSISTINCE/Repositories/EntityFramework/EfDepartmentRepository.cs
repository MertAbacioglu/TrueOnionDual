using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.Services;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Context;

namespace TrueOnion.PERSISTINCE.Repositories.EntityFramework
{
    public class EfDepartmentRepository : EfGenericRepository<Department>, IDepartmentRepository
    {

        public EfDepartmentRepository(EFDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Department>> GetAllAsync(int? skip, int? take)
        {
            IEnumerable<Department> result = await _appDbContext.Departments
                                                                .Skip(skip ?? 0)
                                                                .Take(take ?? _appDbContext.Departments.Count())
                                                                .ToListAsync();
            return result;

        }
    }
}
