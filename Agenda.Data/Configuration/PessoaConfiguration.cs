﻿using Agenda.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Data.Configuration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            //primary key
            builder.HasKey(t => t.Id);

            // propriedades 
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Cidade).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Estado).IsRequired().HasMaxLength(100);

            //TABELA E MAPEAMENTO
            builder.ToTable("pessoas");
            builder.Property(t => t.Id).HasColumnName("ID_PESSOA");
            builder.Property(t => t.Nome).HasColumnName("NOME");
            builder.Property(t => t.Cidade).HasColumnName("CIDADE");
            builder.Property(t => t.Estado).HasColumnName("ESTADO");
        }
    }
}
