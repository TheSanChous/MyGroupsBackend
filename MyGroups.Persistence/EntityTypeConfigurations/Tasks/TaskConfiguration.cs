using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGroups.Domain.Models.Tasks;

namespace MyGroups.Persistence.EntityTypeConfigurations.Tasks
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Title);
            builder.Property(task => task.Description);
            builder.Property(task => task.UploadedAt);
            builder.Property(task => task.PublishedAt);
            builder.Property(task => task.Deadline);
            builder.HasOne(task => task.Group);
            builder.HasOne(task => task.Creator);
            builder.HasOne(task => task.File);
        }
    }
}