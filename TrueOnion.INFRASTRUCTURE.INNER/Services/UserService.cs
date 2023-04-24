using AutoMapper;
using SharpCompress.Common;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.Services;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Exceptions;

namespace TrueOnion.INFRASTRUCTURE.INNER.Services
{
    public class UserService : GenericService<User>,IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IGenericService<Department> _genericService;

        public UserService(IGenericRepository<User> repository, IGenericService<Department> genericService, IUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _genericService = genericService;
            _userRepository = userRepository;
        }

        public async Task<User> AddUserWithDepartmentAsync(User entity)
        {
            Department department = await _genericService.GetByIdAsync(entity.DepartmentId);
            if (department == null)
                throw new NotFoundException(typeof(Department).Name, entity.DepartmentId);
            return await _repository.AddAsync(entity);
        }

        public Task<List<User>> GetAllUsersWithDepartmentAsync()
        {
            return _userRepository.GetAllUsersWithDepartmentAsync();
        }

        public async Task<User> GetUserWithDepartmentAsync(Guid id)
        {
            User user = await _userRepository.GetUserWithDepartmentAsync(id);
            if (user == null)
                throw new NotFoundException(typeof(User).Name, id);
            return user;
            
        }
    }
}
