using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Seeds;
using TrueOnion.PERSISTINCE.Settings;

namespace TrueOnion.PERSISTINCE.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _context;
        private readonly MongoSetting _mongoSetting;
        public MongoDbContext(IConfiguration configuration,IOptions<MongoSetting> mongoSetting)
        {
            _mongoSetting = mongoSetting.Value;
            
            // MongoDb Configuration
            MongoClientSettings settings = MongoClientSettings
                .FromUrl(new MongoUrl(_mongoSetting.ConnectionString));

            MongoClient client = new MongoClient(settings);

            _context = client.GetDatabase((_mongoSetting.DatabaseName));

            // Count the number of Department and User records in the database
            long departmentCount = GetCollection<Department>()
                .CountDocuments(FilterDefinition<Department>.Empty);
            long userCount = GetCollection<Department>()
                            .CountDocuments(FilterDefinition<Department>.Empty);



            // If both Department and User collections are empty, seed the database
            if (departmentCount == 0 && userCount == 0)
                DataSeedExtension.SeedMongo(this);

        }
        
        public IMongoCollection<TEntity> GetCollection<TEntity>()
            => _context.GetCollection<TEntity>(typeof(TEntity).Name.ToLower());
    }
}