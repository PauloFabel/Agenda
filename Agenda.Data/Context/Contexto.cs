using Agenda.Data.Configuration;
using Agenda.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Context
{
    public class Contexto : DbContext
    {
        public Contexto()
        {

        }

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
