using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simpatia.Domain.shared.commands.Adocao;

namespace Simpatia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdocaoController : BaseController
    {
        public AdocaoController([FromServices] IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<ObjectResult> InserirAdocao([FromBody]CriarAdocaoCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-adocoes")]
        public async Task<ObjectResult> BuscaAdocaos([FromBody]BuscarAdocoesCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-adocao")]
        public async Task<ObjectResult> BuscaAdocaosPorId([FromBody]BuscarAdocaoCommand command)
        {
            return await BaseResult(command);
        }
    }
}
