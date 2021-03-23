using Flunt.Validations;

namespace Simpatia.Domain.shared.commands.Eventos
{
    public class CriarEventoCommand : CommandRequest
    {
        public string ImagemId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public string Data { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Descricao," Descricao", "Necessário informar descricao do restaurante")
                    .IsNotNullOrEmpty(Cidade," Cidade", "Necessário informar cidade do restaurante")
                    .IsNotNullOrEmpty(Data," Data", "Necessário informar data do restaurante")
            );
        }
    }
}
