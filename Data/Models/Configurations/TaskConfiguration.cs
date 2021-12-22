using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(task => task.Id);

            builder.Property(task => task.Title);

            builder.Property(task => task.Description);

            builder.Property(task => task.LoadedAt);

            builder.Property(task => task.Deadline);

            builder.HasOne(task => task.Customer);

            builder.HasOne(task => task.Group);

            builder.HasOne(task => task.File);
        }
    }
}
