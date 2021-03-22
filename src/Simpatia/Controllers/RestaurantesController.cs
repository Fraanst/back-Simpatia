using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simpatia.Domain.shared.commands.Restaurante;

namespace Simpatia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : BaseController
    {
        public RestaurantesController([FromServices] IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<ObjectResult> InserirVaga([FromBody]CriarRestauranteCommand command)
        {
            return await BaseResult(command);
        }

        [HttpGet]
        [Route("busca-restaurantes")]
        public async Task<ObjectResult> BuscaRestaurantes([FromBody]BuscarRestaurantesCommand command)
        {
            return await BaseResult(command);
        }

       [HttpGet]
        [Route("busca-restaurante")]
        public async Task<ObjectResult> BuscaRestaurantePorId([FromBody]BuscarRestauranteCommand command)
        {
            return await BaseResult(command);
        }
    }
}
