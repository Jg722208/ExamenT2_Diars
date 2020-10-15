using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models.Maps
{
    public class ElementoMap : IEntityTypeConfiguration<Elemento>
    {
        public void Configure(EntityTypeBuilder<Elemento> builder)
        {
            builder.ToTable("Elemento");
            builder.HasKey(o => o.Id);
        }
    }
}
