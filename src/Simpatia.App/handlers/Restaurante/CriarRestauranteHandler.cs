using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Restaurante;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Restaurante
{
    public class CriarRestauranteHandler : CommandHandler, IRequestHandler<CriarRestauranteCommand, CommandResponse>
    {
        private readonly IRestaurantesRepository _repository;
        private readonly IMediator _mediator;
        public CriarRestauranteHandler(IRestaurantesRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<CommandResponse> Handle(CriarRestauranteCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
