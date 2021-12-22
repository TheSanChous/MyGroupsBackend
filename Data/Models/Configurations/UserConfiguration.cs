using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.FirstName);

            builder.Property(user => user.LastName);

            builder.Property(user => user.Email);

            builder.Property(user => user.HashedPassword);

            builder.Property(user => user.Salt);

            builder.HasOne(user => user.Settings)
                .WithOne(settings => settings.User)
                .HasForeignKey<UserSettings>(userSettings => userSettings.UserId);

            builder.HasMany(user => user.Groups)
                .WithOne(group => group.User);
        }
    }
}
