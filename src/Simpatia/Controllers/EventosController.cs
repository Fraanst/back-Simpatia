using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Simpatia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        public EventosController([FromServices] IMediator mediator)
        {
        }
    }
}