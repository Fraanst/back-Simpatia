using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Noticias;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Noticia
{
    public class BuscarNoticiasHandler : CommandHandler, IRequestHandler<BuscarNoticiasCommand, CommandResponse>
    {
        private readonly INoticiasRepository _repository;
        private readonly IMediator _mediator;
        public BuscarNoticiasHandler(INoticiasRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(BuscarNoticiasCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var noticia = await _repository.ObterNoticias(
                Convert.ToDateTime(request.DataInicial),
                Convert.ToDateTime(request.DataFinal));

            return CreateResponse(noticia, "Noticias encontradas com sucesso!");
        }
    }
}
