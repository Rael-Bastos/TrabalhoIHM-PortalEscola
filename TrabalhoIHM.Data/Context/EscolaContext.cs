using Microsoft.EntityFrameworkCore;
using System;
using TrabalhoIHM.Domain.Configuration;
using TrabalhoIHM.Domain.Entidades;

namespace TrabalhoIHM.Data
{
    public class EscolaContext : DbContext
    {
        

        public EscolaContext (DbContextOptions options) : base(options)
        {
        }
       

        #region DbSet
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Professor> Professor { get; set; }

        #endregion



    }
}
