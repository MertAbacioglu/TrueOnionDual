using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Seeds;

namespace TrueOnion.PERSISTINCE.Context
{
    public class EFDbContext : DbContext
    {

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedEf();
        }

    }
}