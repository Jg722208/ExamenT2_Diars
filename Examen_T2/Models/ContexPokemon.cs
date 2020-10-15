using Examen_T2.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T2.Models
{
    public class ContexPokemon : DbContext
    {
        public DbSet<Pokemon> Pokemones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<Capturar> Capturas { get; set; }

        public ContexPokemon(DbContextOptions<ContexPokemon> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokemonMap());
            modelBuilder.ApplyConfiguration(new ElementoMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CapturaMap());
        }
    }
}
