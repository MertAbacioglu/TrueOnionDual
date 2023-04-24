using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Context;

namespace TrueOnion.PERSISTINCE.Repositories.Mongo
{
    public class MongoUserRepository : MongoGenericRepository<User>, IUserRepository
    {

        public MongoUserRepository(IMongoDbContext context) : base(context)
        {
        }

        public async Task<User> AddUserWithDepartmentAsync(User entity)
        {
            await _context.GetCollection<User>().InsertOneAsync(entity);
            return entity;
        }

        public async Task<List<User>> GetAllUsersWithDepartmentAsync()
        {
            List<User> users = await _context.GetCollection<User>().Find(_ => true).ToListAsync();

            foreach (User? user in users)
            {
                Department department = await _context.GetCollection<Department>().Find(d => d.Id == user.DepartmentId).FirstOrDefaultAsync();
                user.Department = department;
            }

            return users;
        }

        public async Task<User> GetUserWithDepartmentAsync(Guid id)
        {
            var user = await _context.GetCollection<User>().Find(u => u.Id == id).FirstOrDefaultAsync();

            if (user != null)
            {
                var department = await _context.GetCollection<Department>().Find(d => d.Id == user.DepartmentId).FirstOrDefaultAsync();
                user.Department = department;
            }

            return user;
        }
    }
}