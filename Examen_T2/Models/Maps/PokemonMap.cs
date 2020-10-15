using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models.Maps
{
    public class PokemonMap : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemon");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.Elemento).
                WithMany().
                HasForeignKey(o => o.TipoId);
        }
    }
}
