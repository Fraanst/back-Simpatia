using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Noticias;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers
{
    public class CriarNoticiaHandler : CommandHandler, IRequestHandler<CriarNoticiaCommand, CommandResponse>
    {
        private readonly INoticiasRepository _repository;
        private readonly IMediator _mediator;
        public CriarNoticiaHandler(INoticiasRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(CriarNoticiaCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var adocao = await _repository.Inserir(new NoticiaDto{
                NoticiaId = new Guid(),
                ImagemId = request.ImagemId,
                Descricao = request.Descricao,
                Data = request.Data,
                Fonte = request.Fonte
            });
            return CreateResponse(adocao, "Noticia cadastrado com sucesso!");
        }
    }
}
