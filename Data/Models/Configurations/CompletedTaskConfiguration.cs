using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class CompletedTaskConfiguration : IEntityTypeConfiguration<CompletedTask>
    {
        public void Configure(EntityTypeBuilder<CompletedTask> builder)
        {
            builder.HasKey(task => task.Id);

            builder.Property(task => task.Title);

            builder.Property(task => task.Description);

            builder.Property(task => task.LoadedAt);

            builder.HasOne(task => task.Task);

            builder.HasOne(task => task.Grade)
                .WithOne(grade => grade.ComplatedTask)
                .HasForeignKey<Grade>(grade => grade.ComplatedTaskId);

            builder.HasOne(task => task.Performer);
        }
    }
}
