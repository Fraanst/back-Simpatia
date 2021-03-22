using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Eventos
{
    public class BuscarEventoCommand : CommandRequest
    {
        public string eventoId { get; set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(eventoId," eventoId", "Necessário informar eventoId")
            );
        }
    }
}
