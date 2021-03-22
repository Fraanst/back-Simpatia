using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simpatia.Domain.shared.commands.Noticias;

namespace Simpatia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : BaseController
    {
        public NoticiasController([FromServices] IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<ObjectResult> InserirNoticia([FromBody]CriarNoticiaCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-Noticias")]
        public async Task<ObjectResult> BuscaNoticias([FromBody]BuscarNoticiasCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-Noticia")]
        public async Task<ObjectResult> BuscaNoticiaPorId([FromBody]BuscarNoticiaCommand command)
        {
            return await BaseResult(command);
        }
    }
}
