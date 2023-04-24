using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Repositories;
using TrueOnion.DOMAIN.Entities;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Context;
using TrueOnion.PERSISTINCE.Settings;

namespace TrueOnion.PERSISTINCE.Repositories.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using MongoDB.Driver;

    public class MongoGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly IMongoDbContext _context;
        private readonly IMongoCollection<T> _collection;

        public MongoGenericRepository(IMongoDbContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Where(predicate);
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<IQueryable<T>> GetAllAsIQueryable()
        {
            return await Task.FromResult(_collection.AsQueryable());
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            Task<List<T>> a = _collection.Find(_ => true).ToListAsync();
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async void Remove(T entity)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.DeleteOneAsync(filter);
        }

        public async void RemoveRange(IEnumerable<T> entities)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.In(e => e.Id, entities.Select(x => x.Id));
            await _collection.DeleteManyAsync(filter);
        }

        public async Task<T> Update(T entity)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(e => e.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
            return entity;
        }
    }

}
