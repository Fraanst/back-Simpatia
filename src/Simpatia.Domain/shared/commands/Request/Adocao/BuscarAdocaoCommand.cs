using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Adocao
{
    public class BuscarAdocaoCommand : CommandRequest
    {
        public string adocaoId { get; set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(adocaoId," adocaoId", "Necessário informar adocaoId")
            );
        }
    }
}
