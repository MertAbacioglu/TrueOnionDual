using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Context;

namespace TrueOnion.PERSISTINCE.Repositories.Mongo
{
    public class MongoDepartmentRepository : MongoGenericRepository<Department>, IDepartmentRepository
    {
        private readonly IMongoCollection<Department> _departmentCollection;

        public MongoDepartmentRepository(IMongoDbContext context) : base(context)
        {
            _departmentCollection = context.GetCollection<Department>();
        }
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            try
            {
                var departments = await _departmentCollection.Find(d => true).ToListAsync();
                return departments;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<IEnumerable<Department>> GetAllAsync(int? skip, int? take)
        {
            throw new NotImplementedException();
        }
    }
    
}
