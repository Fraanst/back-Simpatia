using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Vagas;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Vagas
{
    public class BuscarVagasHandler : CommandHandler, IRequestHandler<BuscarVagasCommand, CommandResponse>
    {
        private readonly IEmpregoRepository _repository;
        private readonly IMediator _mediator;
        public BuscarVagasHandler(IEmpregoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(BuscarVagasCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
