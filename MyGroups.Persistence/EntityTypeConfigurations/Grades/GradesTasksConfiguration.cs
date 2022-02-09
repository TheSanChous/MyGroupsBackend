using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGroups.Domain.Models.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Persistence.EntityTypeConfigurations.Grades
{
    internal class GradesTasksConfiguration : IEntityTypeConfiguration<GradesTasks>
    {
        public void Configure(EntityTypeBuilder<GradesTasks> builder)
        {
            builder.HasKey(gt => gt.Id);
            builder.HasOne(gt => gt.Grade);
            builder.HasOne(gt => gt.ComletedTask);
        }
    }
}
