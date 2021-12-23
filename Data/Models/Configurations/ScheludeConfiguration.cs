using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Configurations
{
    public class ScheludeConfiguration : IEntityTypeConfiguration<Schelude>
    {
        public void Configure(EntityTypeBuilder<Schelude> builder)
        {
            builder.HasKey(schelude => schelude.Id);

            builder.HasOne(schelude => schelude.Group);

            builder.HasMany(schelude => schelude.Items);
        }
    }
}
