﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(group => group.Id);

            builder.Property(group => group.Title);

            builder.Property(group => group.Description);

            builder.HasOne(group => group.Schelude)
                .WithOne(schelude => schelude.Group);

            builder.HasMany(group => group.Users)
                .WithOne(user => user.Group);

            builder.HasMany(group => group.Publications)
                .WithOne(publication => publication.Group);
        }
    }
}