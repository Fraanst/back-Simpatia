using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Eventos;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.Domain.handlers.Evento
{
    public class BuscarEventosHandler : CommandHandler, IRequestHandler<BuscarEventosCommand, CommandResponse>
    {
        private readonly IEventosRepository _repository;
        private readonly IMediator _mediator;
        public BuscarEventosHandler(IEventosRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(BuscarEventosCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var evento = await _repository.ObterEventos(
                Convert.ToDateTime(request.DataInicial),
                Convert.ToDateTime(request.DataFinal));

            return CreateResponse(evento, "Eventos encontrados com sucesso!");
        }
    }
}
