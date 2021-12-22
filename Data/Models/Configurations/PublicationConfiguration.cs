using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class PublicationConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.HasKey(publication => publication.Id);

            builder.Property(publication => publication.DateTime);

            builder.Property(publication => publication.Description);

            builder.Property(publication => publication.Title);

            builder.HasOne(publication => publication.Group)
                .WithMany(group => group.Publications);

            builder.HasOne(publication => publication.User);
        }
    }
}
