using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.APPLICATION.Services;
using TrueOnion.APPLICATION.UnitOfWork;
using TrueOnion.APPLICATION.Wrappers;
using TrueOnion.DOMAIN.Entities;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Exceptions;
using TrueOnion.PERSISTINCE.UnitOfWork;

namespace TrueOnion.INFRASTRUCTURE.INNER
{
    public class GenericService<Entity> : IGenericService<Entity> where Entity : BaseEntity

    {
        private readonly IGenericRepository<Entity> _repository;

        public GenericService(IGenericRepository<Entity> repository)
        {
            _repository = repository;
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<List<Entity>> AddRangeAsync(IEnumerable<Entity> entities)
        {
            return (await _repository.AddRangeAsync(entities)).ToList();
        }

        public async Task<List<Entity>> FindAsync(Expression<Func<Entity, bool>> predicate)
        {
            IEnumerable<Entity> result = await _repository.FindAsync(predicate);
            return result.ToList();
        }

        public async Task<List<Entity>> GetAllAsync()
        {

            return (await _repository.GetAllAsync()).ToList();
        }

        public async Task<Entity> GetByIdAsync(Guid id)
        {
            Entity result = await _repository.GetByIdAsync(id);
            if (result == null)
                throw new NotFoundException(typeof(Entity).Name, id);
            return await _repository.GetByIdAsync(id);
        }

        public async void Remove(Guid id)
        {
            Entity result = await GetByIdAsync(id);

            _repository.Remove(result);
            {
                _repository.Remove(result);


            }
        }

        public void RemoveRange(IEnumerable<Entity> entities)
        {
            _repository.RemoveRange(entities);
        }

        public async Task<Entity> Update(Entity entity)
        {
            Entity result = await GetByIdAsync(entity.Id); //before update, check if it is exist or not
            return await _repository.Update(entity);//toDo: mert
        }
    }
}