using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simpatia.Domain.shared.commands;

namespace Simpatia.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController([FromServices]IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ObjectResult> BaseResult([FromBody]CommandRequest request)
        {
            try
            {
                request.Validate();
                if (request.Invalid)
                    return StatusCode(400, new CommandResponse(400, "Requisição inválida", request.Notifications));
            }
            catch
            {
                return StatusCode(400, new CommandResponse(400, "Requisição inválida", null));
            }

            try
            {
                var result = await _mediator.Send(request);
                return StatusCode(result.StatusCode, result);
            }
            catch
            {
                return StatusCode(500, new CommandResponse(500, "Ops, algo deu errado", null));
            }
        }
    }
}
