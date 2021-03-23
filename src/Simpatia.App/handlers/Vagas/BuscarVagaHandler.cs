using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Vagas;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Vagas
{
    public class BuscarVagaHandler : CommandHandler, IRequestHandler<BuscarVagaCommand, CommandResponse>
    {
        private readonly IEmpregoRepository _repository;
        private readonly IMediator _mediator;
        public BuscarVagaHandler(IEmpregoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<CommandResponse> Handle(BuscarVagaCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
