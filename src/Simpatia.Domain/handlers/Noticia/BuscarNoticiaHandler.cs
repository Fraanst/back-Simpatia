using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Noticias;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.Domain.handlers.Noticia
{
    public class BuscarNoticiaHandler : CommandHandler, IRequestHandler<BuscarNoticiaCommand, CommandResponse>
    {
        private readonly INoticiasRepository _repository;
        private readonly IMediator _mediator;
        public BuscarNoticiaHandler(INoticiasRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(BuscarNoticiaCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var noticia = await _repository.ObterPorId(request.noticiaId);
            return CreateResponse(noticia, "Noticia encontrado com sucesso!");
        }
    }
}
