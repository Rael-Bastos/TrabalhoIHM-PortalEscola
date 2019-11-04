using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrabalhoIHM.Business.Dto;
using TrabalhoIHM.Domain.Entidades;
using TrabalhoIHM.Domain.Interfaces.Repositorio;
using TrabalhoIHM.Domain.Interfaces.Services;
using TrabalhoIHM.Domain.Interfaces.UoW;

namespace TrabalhoIHM.Business.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AlunoService(IAlunoRepository aluno, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _alunoRepository = aluno;

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Aluno> AddAluno(AlunoDto aluno)
        {
            var adAluno = new Aluno();
            adAluno= _mapper.Map<Aluno>(aluno);
            _alunoRepository.Save(adAluno);
            await _unitOfWork.CommitAsync();

            return adAluno;
        }

        public async Task<IList<AlunoDto>> GetAluno()
        {
            var alunosRepository = await _alunoRepository.GetAll();
            var alunos = _mapper.Map<List<AlunoDto>>(alunosRepository);

            return alunos;
        }

        public async Task<Aluno> EditAluno(AlunoDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            _alunoRepository.AlterarAsync(aluno);
            await _unitOfWork.CommitAsync();

            return aluno;
        }

        public async Task<AlunoDto> DetalhesAluno(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            
            return alunoDto;
        }

        public async Task ExcluirAluno(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            _alunoRepository.Delete(aluno);
            await _unitOfWork.CommitAsync();

            return;
        }
    }
}
