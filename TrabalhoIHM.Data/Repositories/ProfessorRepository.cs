using System;
using System.Collections.Generic;
using System.Text;
using TrabalhoIHM.Domain.Entidades;
using TrabalhoIHM.Domain.Interfaces.Repositorio;

namespace TrabalhoIHM.Data.Repositories
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(EscolaContext context) : base(context)
        {
        }

    }
}
