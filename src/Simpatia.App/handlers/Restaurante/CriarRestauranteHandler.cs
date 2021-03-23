using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.ApiDto;
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

        public async Task<CommandResponse> Handle(CriarRestauranteCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var restaurante = await _repository.Inserir(new RestaurantesDto{
                RestauranteId = new Guid(),
                ImagemId = request.ImagemId,
                Site = request.Site,
                Descricao = request.Descricao,
                Data = request.Data,
                Telefone = request.Telefone,
                Endereco = request.Endereco,
                Cidade = request.Cidade,
                Salario = request.Salario
            });
            return CreateResponse(restaurante, "Restaurante cadastrado com sucesso!");
        }
    }
}
