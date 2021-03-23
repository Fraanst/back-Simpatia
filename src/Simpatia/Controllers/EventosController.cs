using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simpatia.Domain.shared.commands.Eventos;

namespace Simpatia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : BaseController
    {
        public EventosController([FromServices] IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<ObjectResult> InserirEvento([FromBody]CriarEventoCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-evento")]
        public async Task<ObjectResult> BuscaEventoPorId([FromBody]BuscarEventoCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-eventos")]
        public async Task<ObjectResult> BuscaEventos([FromBody]BuscarEventosCommand command)
        {
            return await BaseResult(command);
        }
    }
}
