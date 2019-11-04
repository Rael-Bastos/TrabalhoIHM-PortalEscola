using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TrabalhoIHM.Business.Dto;
using TrabalhoIHM.Business.Services;
using TrabalhoIHM.Data.Repositories;
using TrabalhoIHM.Data.UoW;
using TrabalhoIHM.Domain.Entidades;
using TrabalhoIHM.Domain.Interfaces.Repositorio;
using TrabalhoIHM.Domain.Interfaces.Services;
using TrabalhoIHM.Domain.Interfaces.UoW;

namespace TrabalhoIHM.CrossCutting
{
    public class RegisterDependencies
    {
        private static IServiceCollection _services { get; set; }

        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProfessorService, ProfessorService>();

            
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddScoped<IMapper, Mapper>(x =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Aluno, AlunoDto>();

                });
                return new Mapper(config);
            });

            services.AddScoped<IMapper, Mapper>(x =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Professor, ProfessorDto>();

                });
                return new Mapper(config);
            });

            _services = services;
        }
            public static TService GetService<TService>()
            {
                return (TService)_services.FirstOrDefault().ImplementationInstance;
            }
    }
}

