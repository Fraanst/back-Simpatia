using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Noticias
{
    public class BuscarNoticiaCommand : CommandRequest
    {
        public string noticiaId { get; set; }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(noticiaId," noticiaId", "Necessário informar noticiaId")
            );
        }
    }
}
