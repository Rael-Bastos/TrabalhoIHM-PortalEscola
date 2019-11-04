using System.Collections.Generic;
using System.Threading.Tasks;
using TrabalhoIHM.Business.Dto;
using TrabalhoIHM.Domain.Entidades;

namespace TrabalhoIHM.Domain.Interfaces.Services
{
   public interface IProfessorService
    {
        Task<Professor> AddProfessor(ProfessorDto professorDto);
        Task<IList<ProfessorDto>> GetProfessor();
        Task<Professor> EditProfessor(ProfessorDto professorDto);
        Task<ProfessorDto> DetalhesProfessor(int id);
        Task ExcluirProfessor(int id);
    }
}
