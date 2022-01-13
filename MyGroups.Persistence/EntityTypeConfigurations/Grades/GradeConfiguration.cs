using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGroups.Domain.Models.Grades;

namespace MyGroups.Persistence.EntityTypeConfigurations.Grades
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.HasKey(grade => grade.Id);
            builder.Property(grade => grade.Description);
            builder.Property(grade => grade.Value);
            builder.HasOne(grade => grade.User);
            builder.HasOne(grade => grade.Evaluator);
        }
    }
}