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

        public async Task<CommandResponse> Handle(BuscarVagaCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var vaga = await _repository.ObterPorId(request.vagaId);
            return CreateResponse(vaga, "Vagas encontrado com sucesso!");
        }
    }
}
