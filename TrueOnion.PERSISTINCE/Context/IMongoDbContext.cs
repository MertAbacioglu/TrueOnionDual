using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueOnion.PERSISTINCE.Context
{
    public interface IMongoDbContext
    {
        public IMongoCollection<TEntity> GetCollection<TEntity>();

    }
}
