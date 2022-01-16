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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(group => group.Id);

            builder.Property(group => group.Title);

            builder.Property(group => group.Description);

            builder.HasIndex(group => group.Identifier)
                .IsUnique();

            builder.Property(group => group.CreationDate);
        }
    }
}
