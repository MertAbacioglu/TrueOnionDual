using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.APPLICATION.Services
{
    public interface IUserService : IGenericService<User>
    {
        public Task<User> AddUserWithDepartmentAsync(User entity);
        public Task<User> GetUserWithDepartmentAsync(Guid id);
        public Task<List<User>> GetAllUsersWithDepartmentAsync();

    }
}
