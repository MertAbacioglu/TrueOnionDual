using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.APPLICATION.Services
{
    public interface IDepartmentService : IGenericService<Department>
    {
        public Task<List<Department>> GetAll(int? skip, int? take);
    }
}
