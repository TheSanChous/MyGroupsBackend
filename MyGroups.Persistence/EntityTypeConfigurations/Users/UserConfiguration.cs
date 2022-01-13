using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGroups.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Persistence.EntityTypeConfigurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name);

            builder.Property(user => user.Surname);

            builder.Property(user => user.Email);

            builder.Property(user => user.HashedPassword);

            builder.Property(user => user.Salt);
        }
    }
}
