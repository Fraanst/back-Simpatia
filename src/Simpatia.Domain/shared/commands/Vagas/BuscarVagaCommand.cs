using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Vagas
{
    public class BuscarVagaCommand : CommandRequest
    {
        public string vagaId { get; set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(vagaId," vagaId", "Necessário informar vagaId")
            );
        }
    }
}
