using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.DOMAIN.Entities.Concretes;
using TrueOnion.PERSISTINCE.Seeds;

namespace TrueOnion.PERSISTINCE.Configurations.EFConfigurations
{

    public class DepartmentMap : BaseMap<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {

            base.Configure(builder);
        }
    }
}
