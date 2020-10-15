using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models.Maps
{
    public class CapturaMap : IEntityTypeConfiguration<Capturar>
    {
        public void Configure(EntityTypeBuilder<Capturar> builder)
        {
            builder.ToTable("UsuarioPokemon");
            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.Pokemon)
                .WithMany(x => x.Capturas)
                .HasForeignKey(o => o.IdPokemon);
        }
    }
}
