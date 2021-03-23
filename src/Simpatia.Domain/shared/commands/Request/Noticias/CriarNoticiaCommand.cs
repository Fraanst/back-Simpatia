using System;
using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Noticias
{
    public class CriarNoticiaCommand : CommandRequest
    {
        public Guid ImagemId { get; set; }
        public string Descricao { get; set; }
        public string Fonte { get; set; }
        public string Data { get; set; }
        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Descricao," Descricao", "Necessário informar descricao do restaurante")
                    .IsNotNullOrEmpty(Fonte," Telefone", "Necessário informar fonte do restaurante")
            );
        }
    }
}
