using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGroups.Domain.Models.Tasks;

namespace MyGroups.Persistence.EntityTypeConfigurations.Tasks
{
    public class CompletedTaskConfiguration : IEntityTypeConfiguration<CompletedTask>
    {
        public void Configure(EntityTypeBuilder<CompletedTask> builder)
        {
            builder.HasKey(completedTask => completedTask.Id);
            builder.Property(completedTask => completedTask.Title);
            builder.Property(completedTask => completedTask.Description);
            builder.Property(completedTask => completedTask.UploadedAt);
            builder.HasOne(completedTask => completedTask.Creator);
            builder.HasOne(completedTask => completedTask.File);
            builder.HasOne(completedTask => completedTask.Task);
            builder.HasOne(completedTask => completedTask.Grade);
        }
    }
}