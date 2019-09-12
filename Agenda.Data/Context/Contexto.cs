using Agenda.Data.Domain;
using Agenda.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Context
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions options) : base(options)
        {
        }
            public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
