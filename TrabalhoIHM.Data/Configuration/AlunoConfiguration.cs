using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoIHM.Domain.Entidades;

namespace TrabalhoIHM.Domain.Configuration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> modelbuilder)
        {
            modelbuilder.ToTable("ALUNO");


            modelbuilder
                .HasKey(a => a.Id);
            modelbuilder
                .Property(a => a.Nome)
                .HasColumnName("NOME");
            modelbuilder
                .Property(a => a.Cpf)
                .HasColumnName("CPF");
            modelbuilder
                .Property(a => a.DataNascimento)
                .HasColumnName("DATA_NASCIMENTO");
            modelbuilder
                .Property(a => a.Idade)
                .HasColumnName("IDADE");
            modelbuilder
                .Property(a => a.Telefone)
                .HasColumnName("TELEFONE");
            modelbuilder
                .Property(a => a.Celular)
                .HasColumnName("CELULAR");
            modelbuilder
                .Property(a => a.Endereco)
                .HasColumnName("ENDERECO");
            modelbuilder
                .Property(a => a.CEP)
                .HasColumnName("CEP");
            modelbuilder
                .Property(a => a.Email)
                .HasColumnName("EMAIL");
            
        }
    }
}
