using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Eventos;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.Domain.handlers.Evento
{
    public class CriarEventoHandler : CommandHandler, IRequestHandler<CriarEventoCommand, CommandResponse>
    {
        private readonly IEventosRepository _repository;
        private readonly IMediator _mediator;
        public CriarEventoHandler(IEventosRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(CriarEventoCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return CreateResponse(null, "Evento não pode ser criado.");

            var evento = await _repository.Inserir(new EventosDto{
                EventoId = new Guid(),
                Nome = request.Nome,
                ImagemId = request.ImagemId,
                Descricao = request.Descricao,
                Telefone = request.Telefone,
                Site = request.Site,
                Data = request.Data,
                Endereco = request.Endereco,
                Cidade = request.Cidade});
            return CreateResponse(evento, "Evento cadastrado com sucesso!");
        }
    }
}
