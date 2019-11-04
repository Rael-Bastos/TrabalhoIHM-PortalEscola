using System.Collections.Generic;
using System.Threading.Tasks;
using TrabalhoIHM.Business.Dto;
using TrabalhoIHM.Domain.Entidades;

namespace TrabalhoIHM.Domain.Interfaces.Services
{
   public interface IAlunoService
    {
        Task<Aluno> AddAluno(AlunoDto alunoDto);
        Task<IList<AlunoDto>> GetAluno();
        Task<Aluno> EditAluno(AlunoDto alunoDto);
        Task<AlunoDto> DetalhesAluno(int id);
        Task ExcluirAluno(int id);
    }
}
