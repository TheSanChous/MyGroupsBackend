using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyGroups.Domain.Models.Files;

namespace MyGroups.Persistence.EntityTypeConfigurations.Files
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.HasKey(file => file.Id);

            builder.Property(file => file.Url);
            
            builder.Property(file => file.Name);
            
            builder.Property(file => file.BlobName);
        }
    }
}