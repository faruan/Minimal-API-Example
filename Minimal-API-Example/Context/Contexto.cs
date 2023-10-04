using Microsoft.EntityFrameworkCore;
using Minimal_API_Example.Domain.Entities;

namespace Minimal_API_Example.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => 
            modelBuilder.Entity<CidadeEntity>().HasKey(cidade => cidade.Id);

        public DbSet<CidadeEntity> Cidades { get; set; }

    }
}
