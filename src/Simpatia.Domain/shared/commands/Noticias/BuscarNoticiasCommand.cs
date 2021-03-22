using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Noticias
{
    public class BuscarNoticiasCommand : CommandRequest
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(DataFinal," DataFinal", "Necessário informar data final")
            );
        }
    }
}
