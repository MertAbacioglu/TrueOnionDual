using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.APPLICATION.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> AddUserWithDepartmentAsync(User entity);
        public Task<User> GetUserWithDepartmentAsync(Guid id);
        public Task<List<User>> GetAllUsersWithDepartmentAsync();
        
        
        
        

    }
}
