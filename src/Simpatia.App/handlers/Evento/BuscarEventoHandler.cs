using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Eventos;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Evento
{
    public class BuscarEventoHandler : CommandHandler, IRequestHandler<BuscarEventoCommand, CommandResponse>
    {
        private readonly IEventosRepository _repository;
        private readonly IMediator _mediator;
        public BuscarEventoHandler(IEventosRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        public async Task<CommandResponse> Handle(BuscarEventoCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var evento = await _repository.ObterPorId(request.eventoId);
            return CreateResponse(evento, "Eventos encontrado com sucesso!");
        }
    }
}
