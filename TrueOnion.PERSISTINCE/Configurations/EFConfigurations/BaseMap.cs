using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.Bson;
using TrueOnion.DOMAIN.Entities;
using TrueOnion.PERSISTINCE.Seeds;

namespace TrueOnion.PERSISTINCE.Configurations.EFConfigurations
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

        }
    }
}
