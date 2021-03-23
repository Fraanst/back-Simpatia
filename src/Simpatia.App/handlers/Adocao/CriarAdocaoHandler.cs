using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Adocao;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Adocao
{
    public class CriarAdocaoHandler : CommandHandler, IRequestHandler<CriarAdocaoCommand, CommandResponse>
    {
        private readonly IAdocaoRepository _repository;
        private readonly IMediator _mediator;
        public CriarAdocaoHandler(IAdocaoRepository repository, IMediator mediator)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<CommandResponse> Handle(CriarAdocaoCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var adocao = await _repository.Inserir(new AdocaoDto{
                Descricao = request.Descricao,
                Data = request.Data,
                Cidade = request.Cidade,
                ImagemId = request.ImagemId,
                Tipo = request.Tipo,
                Endereco = request.Endereco,
                Telefone = request.Telefone,
            });
            return CreateResponse(adocao, "Adocao cadastrado com sucesso!");
        }
    }
}
