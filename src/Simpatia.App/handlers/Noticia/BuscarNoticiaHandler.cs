using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Noticias;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Noticia
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

        public Task<CommandResponse> Handle(BuscarNoticiaCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
