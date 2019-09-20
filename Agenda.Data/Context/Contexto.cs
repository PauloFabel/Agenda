using Agenda.Data.Configurations;
using Agenda.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Context
{
    public class Contexto : DbContext
    {
        public Contexto()
        {

        }

        /// <summary>
        /// Cria a Conexão
        /// </summary>
        /// <param name="options"></param>
        public Contexto(DbContextOptions options) : base(options)
        {

        }

        /// <summary>
        /// Cria a tabela
        /// </summary>
        public DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
