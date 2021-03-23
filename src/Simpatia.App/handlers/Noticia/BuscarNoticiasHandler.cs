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

        public Task<CommandResponse> Handle(BuscarNoticiasCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
