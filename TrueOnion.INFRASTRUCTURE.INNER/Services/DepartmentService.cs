using AutoMapper;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.Services;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.INFRASTRUCTURE.INNER.Services
{
    public class DepartmentService : GenericService<Department>,IDepartmentService
    {
        private readonly IGenericRepository<Department> _repository;

        public DepartmentService(IGenericRepository<Department> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Department>> GetAll(int? skip, int? take)
        {
            IQueryable<Department> result = await _repository.GetAllAsIQueryable();

            List<Department> response = (await _repository.GetAllAsIQueryable())
                                                        .Skip(skip ?? 0)
                                                        .Take(take ?? result.Count())
                                                        .ToList();
            return response;

        }
    }
}