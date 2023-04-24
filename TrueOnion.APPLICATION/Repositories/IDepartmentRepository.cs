using Microsoft.AspNetCore.Mvc;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.APPLICATION.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public Task<IEnumerable<Department>> GetAllAsync(int? skip, int? take);
    }
}
