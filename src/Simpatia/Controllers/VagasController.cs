using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simpatia.Domain.commands;
using Simpatia.Domain.shared.commands.Vagas;

namespace Simpatia.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VagasController : BaseController
    {
        public VagasController([FromServices] IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<ObjectResult> InserirVaga([FromBody]CriarVagaCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-vagas")]
        public async Task<ObjectResult> BuscaVagas([FromBody]BuscarVagasCommand command)
        {
            return await BaseResult(command);
        }
        [HttpGet]
        [Route("busca-vagas")]
        public async Task<ObjectResult> BuscaVagaPorId([FromBody]BuscarVagaCommand command)
        {
            return await BaseResult(command);
        }
    }
}
