using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.commands;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.shared.commands;
using Simpatia.Domain.shared.Handlers;

namespace Simpatia.Domain.handlers
{
    public class CriarVagaHandler : CommandHandler, IRequestHandler<CriarVagaCommand, CommandResponse>
    {
        private readonly IEmpregoRepository _repository;
        private readonly IMediator _mediator;
        public CriarVagaHandler(IEmpregoRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> Handle(CriarVagaCommand request, CancellationToken cancellationToken)
        {
            if (request.Valid)
                return null;

            var vaga = await _repository.Inserir(new EmpregoDto{
                VagaId = new Guid(),
                Cargo = request.Cargo,
                Descricao = request.Descricao,
                Data = request.Data,
                Telefone = request.Telefone,
                Empresa = request.Empresa,
                Endereco = request.Endereço,
                Cidade = request.Cidade,
                Salario = request.Salario
            });
            return CreateResponse(vaga, "Vaga cadastrado com sucesso!");
        }
    }
}
