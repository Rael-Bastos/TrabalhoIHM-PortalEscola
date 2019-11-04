using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TrabalhoIHM.Api.Controllers
{
    public class ControllerBaseExtension : ControllerBase
    {
            /// <summary>
            /// Retorna BadRequest com mensagens de exceção
            /// </summary>
            /// <param name="ex">Exception</param>
            /// <returns>BadRequestObjectResult</returns>
            [NonAction]
            public BadRequestObjectResult BadRequest(Exception ex)
            {
                var message = $"Mensagem: {ex.Message} \n {ex.InnerException?.Message}";

                return BadRequest(message);
            }

    }
}