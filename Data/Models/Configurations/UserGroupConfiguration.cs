using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(userGroup => userGroup.Id);

            builder.HasOne(userGroup => userGroup.User);

            builder.HasOne(userGroup => userGroup.Group);

            builder.HasOne(userGroup => userGroup.User);

            builder.HasOne(userGroup => userGroup.RoleInGroup);
        }
    }
}
