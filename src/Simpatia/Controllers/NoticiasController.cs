using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Simpatia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        public NoticiasController([FromServices] IMediator mediator)
        {
        }
    }
}
