using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Restaurante;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.Domain.handlers
{
    public class BuscarRestauranteHandler : CommandHandler, IRequestHandler<BuscarRestauranteCommand, CommandResponse>
    {
        private readonly IRestaurantesRepository _repository;
        private readonly IMediator _mediator;
        public BuscarRestauranteHandler(IRestaurantesRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(BuscarRestauranteCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var restaurante = await _repository.ObterPorId(request.restauranteId);
            return CreateResponse(restaurante, "Restaurante encontrado com sucesso!");
        }
    }
}
