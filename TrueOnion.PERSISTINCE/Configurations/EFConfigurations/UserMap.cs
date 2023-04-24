using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrueOnion.DOMAIN.Entities.Concretes;

namespace TrueOnion.PERSISTINCE.Configurations.EFConfigurations
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder
               .HasOne(p => p.Department)
               .WithMany(c => c.Users)
               .HasForeignKey(p => p.DepartmentId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired(false);
            
        }
    }
}
