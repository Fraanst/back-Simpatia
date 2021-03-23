namespace Simpatia.App.handlers
{
    public class BuscarRestauranteHandler : CommandHandler, IRequestHandler<BuscarRestaurantesCommand, CommandResponse>
    {
        private readonly IRestaurantesRepository _repository;
        private readonly IMediator _mediator;
        public BuscarRestaurantesHandler(IRestaurantesRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public Task<CommandResponse> Handle(BuscarRestaurantesCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var restaurante = await _repository.ObterPorId(request.restauranteId);
            return CreateResponse(restaurante, "Restaurante encontrado com sucesso!");
        }
    }
}
