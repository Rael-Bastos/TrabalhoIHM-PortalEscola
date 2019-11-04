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
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorService(IProfessorRepository professor, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _professorRepository = professor;

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Professor> AddProfessor(ProfessorDto professor)
        {
            var adProfessor = new Professor();
            adProfessor = _mapper.Map<Professor>(professor);
            _professorRepository.Save(adProfessor);
            await _unitOfWork.CommitAsync();

            return adProfessor;
        }

        public async Task<IList<ProfessorDto>> GetProfessor()
        {
            var professorRepository = await _professorRepository.GetAll();
            var professors = _mapper.Map<List<ProfessorDto>>(professorRepository);

            return professors;
        }

        public async Task<Professor> EditProfessor(ProfessorDto professorDto)
        {
            var professor = _mapper.Map<Professor>(professorDto);
            _professorRepository.AlterarAsync(professor);
            await _unitOfWork.CommitAsync();

            return professor;
        }

        public async Task<ProfessorDto> DetalhesProfessor(int id)
        {
            var professor = await _professorRepository.GetById(id);
            var professorDto = _mapper.Map<ProfessorDto>(professor);
            
            return professorDto;
        }

        public async Task ExcluirProfessor(int id)
        {
            var professor = await _professorRepository.GetById(id);
            _professorRepository.Delete(professor);
            await _unitOfWork.CommitAsync();

            return;
        }
    }
}
