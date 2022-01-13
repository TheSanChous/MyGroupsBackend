using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGroups.Domain.Models.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Persistence.EntityTypeConfigurations.Groups
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.HasKey(userGroup => userGroup.Id);

            builder.HasOne(userGroup => userGroup.User);

            builder.HasOne(userGroup => userGroup.Group);

            builder.Property(userGroup => userGroup.Role)
                .IsRequired()
                .HasConversion<string>();
        }
    }
}
