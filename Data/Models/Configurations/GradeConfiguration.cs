using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(grade => grade.Id);

            builder.Property(grade => grade.Value);

            builder.Property(grade => grade.Description);

            builder.HasOne(grade => grade.ComplatedTask)
                .WithOne(task => task.Grade);
        }
    }
}
