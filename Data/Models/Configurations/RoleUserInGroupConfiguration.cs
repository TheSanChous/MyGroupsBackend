using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class RoleUserInGroupConfiguration : IEntityTypeConfiguration<RoleUserInGroup>
    {
        public void Configure(EntityTypeBuilder<RoleUserInGroup> builder)
        {
            builder.HasKey(role => role.Id);

            builder.Property(role => role.Title);

            builder.HasData(new[]
            {
                new RoleUserInGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "Admin"
                },
                new RoleUserInGroup
                {
                    Id = Guid.NewGuid(),
                    Title = "Member"
                }
            });
               
        }
    }
}
