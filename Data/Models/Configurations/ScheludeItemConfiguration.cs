using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class ScheludeItemConfiguration : IEntityTypeConfiguration<ScheludeItem>
    {
        public void Configure(EntityTypeBuilder<ScheludeItem> builder)
        {
            builder.HasKey(schludeItem => schludeItem.Id);

            builder.Property(schludeItem => schludeItem.Titile);

            builder.Property(schludeItem => schludeItem.Description);

            builder.Property(schludeItem => schludeItem.DateTime);

            builder.HasOne(schludeItem => schludeItem.Schelude)
                .WithMany(schelude => schelude.Items);
        }
    }
}
