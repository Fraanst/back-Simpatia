using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.commands;
using Simpatia.Domain.models;

namespace Simpatia.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {

        // /// <summary>
        // ///  Criar Nova Vaga
        // /// </summary>
        // /// <param name="input"></param>
        // /// <response code="200">Sucesso</response>
        // /// <response code="500">Erro interno</response>
        // [HttpPost("")]
        // [ProducesResponseType(typeof(EmpregoDto), 200)]
        // [ProducesResponseType(500)]
        // public async Task<Emprego> CriarVaga(
        // [FromServices] IMediator mediator, [FromBody] CriarVagaCommand command)
        // {

        // }
    }
}
