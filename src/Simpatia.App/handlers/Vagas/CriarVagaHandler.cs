using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.commands;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers
{
    public class CriarVagaHandler : CommandHandler, IRequestHandler<CriarVagaCommand, CommandResponse>
    {
        private readonly IEmpregoRepository _repository;
        private readonly IMediator _mediator;
        public CriarVagaHandler(IEmpregoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(CriarVagaCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
