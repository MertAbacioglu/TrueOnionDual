using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Context;

namespace TrueOnion.PERSISTINCE.Seeds
{
    public static class DataSeedExtension
    {
        public static void SeedEf(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(FakeDataGenerator.Departments);
            modelBuilder.Entity<User>().HasData(FakeDataGenerator.Users);
        }

        public static void SeedMongo(this IMongoDbContext context)
        {
            context.GetCollection<User>().InsertMany(FakeDataGenerator.Users);
            context.GetCollection<Department>().InsertMany(FakeDataGenerator.Departments);
        }
    }
}