using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Restaurante
{
    public class BuscarRestauranteCommand : CommandRequest
    {
        public string restauranteId { get; set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(restauranteId," restauranteId", "Necessário informar restauranteId")
            );
        }
    }
}
