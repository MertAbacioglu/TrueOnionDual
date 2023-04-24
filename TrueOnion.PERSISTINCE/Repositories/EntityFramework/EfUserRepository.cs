using Microsoft.EntityFrameworkCore;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.UnitOfWork;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Context;

namespace TrueOnion.PERSISTINCE.Repositories.EntityFramework
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDepartmentRepository _departmentRepository;

        public EfUserRepository(EFDbContext appDbContext, IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository) : base(appDbContext)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
        }

        public async Task<User> AddUserWithDepartmentAsync(User entity)
        {
            return await AddAsync(entity);

        }

        public async Task<List<User>> GetAllUsersWithDepartmentAsync()
        {
            List<User> entities = await _appDbContext.Users.Include(x => x.Department).ToListAsync();
            return entities;
        }

        public async Task<User> GetUserWithDepartmentAsync(Guid id)
        {
            User user = await _appDbContext.Users.Include(x=>x.Department).FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}