using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TrabalhoIHM.Business.Dto;
using TrabalhoIHM.Domain.Interfaces.Services;

namespace TrabalhoIHM.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AlunoController : ControllerBaseExtension
    {
        private readonly IAlunoService _alunoService;

        public AlunoController (IAlunoService alunoService)
        {
            _alunoService = alunoService;

        }

        [HttpPost]
        public async Task<ActionResult> AdicionarAluno(AlunoDto alunoDto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var retorno = await _alunoService.AddAluno(alunoDto);
                    return Ok(retorno);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ListarAlunos()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = await _alunoService.GetAluno();
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
        public async Task<IActionResult> DetalhesAluno( int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = await _alunoService.DetalhesAluno(id);
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
        public async Task<IActionResult> EditarAluno(AlunoDto alunoDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var retorno = await _alunoService.EditAluno(alunoDto);
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
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     await _alunoService.ExcluirAluno(id);
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