using Flunt.Validations;
using Simpatia.Domain.shared.commands;

namespace Simpatia.Domain.commands
{
    public class CriarVagaCommand : CommandRequest
    {
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public string Descricao { get; set; }
        public string Endereço { get; set; }
        public double Salario { get; set; }
        public string Data { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(Cargo, "Cargo", "Necessário informar cargo")
                    .IsNotNullOrEmpty(Descricao, "Descricao", "Necessário informar descrição da vaga")
                    .IsNotNullOrEmpty(Cidade," Cidade", "Necessário informar cidade")
            );
        }
    }
}
