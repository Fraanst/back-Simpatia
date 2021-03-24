using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Adocao;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.Domain.handlers.Adocao
{
    public class BuscarAdocaoHandler : CommandHandler, IRequestHandler<BuscarAdocaoCommand, CommandResponse>
    {
        private readonly IAdocaoRepository _repository;
        private readonly IMediator _mediator;

        public BuscarAdocaoHandler(IAdocaoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(BuscarAdocaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;
            var adocao = await _repository.ObterPorId(request.adocaoId);
            return CreateResponse(adocao, "Adocao encontrado com sucesso!");
        }
    }
}
