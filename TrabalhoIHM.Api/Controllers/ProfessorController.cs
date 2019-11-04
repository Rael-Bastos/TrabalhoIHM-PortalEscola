using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoIHM.Business.Dto;
using TrabalhoIHM.Domain.Interfaces.Services;

namespace TrabalhoIHM.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProfessorController : ControllerBaseExtension
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;

        }

        [HttpGet]
        public async Task<ActionResult> ListarProfessor()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = await _professorService.GetProfessor();
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> AdicionarProfessor(ProfessorDto professorDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = await _professorService.AddProfessor(professorDto);
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> DetalhesProfessor(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = await _professorService.DetalhesProfessor(id);
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditarProfessor(ProfessorDto professorDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = await _professorService.EditProfessor(professorDto);
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ExcluirProfessor(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _professorService.ExcluirProfessor(id);
                    return Ok();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
