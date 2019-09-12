using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Agenda.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Data.Configuration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            //primary key
            builder.HasKey(t => t.id);

            // propriedades 
            builder.Property(t => t.nome).IsRequired().HasMaxLength(100);
            builder.Property(t => t.cidade).IsRequired().HasMaxLength(100);
            builder.Property(t => t.estado).IsRequired().HasMaxLength(100);

            //TABELA E MAPEAMENTO
            builder.ToTable("pessoas");
            builder.Property(t => t.id).HasColumnName("ID_PESSOA");
            builder.Property(t => t.nome).HasColumnName("NOME");
            builder.Property(t => t.cidade).HasColumnName("CIDADE");
            builder.Property(t => t.nome).HasColumnName("ESTADO");
        }
    }
}
