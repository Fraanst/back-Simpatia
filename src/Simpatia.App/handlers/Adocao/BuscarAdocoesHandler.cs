using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.commands.Adocao;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.App.handlers.Adocao
{
    public class BuscarAdocoesHandler : CommandHandler, IRequestHandler<BuscarAdocoesCommand, CommandResponse>
    {
        private readonly IAdocaoRepository _repository;
        private readonly IMediator _mediator;

        public async Task<CommandResponse> Handle(BuscarAdocoesCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var adocao = await _repository.ObterAdocoes(
                Convert.ToDateTime(request.DataInicial),
                Convert.ToDateTime(request.DataFinal));

            return CreateResponse(adocao, "Adocoes encontradas com sucesso!");
        }
    }
}
