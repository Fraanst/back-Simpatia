namespace Simpatia.Domain.models
{
    public class Emprego
    {
        public Emprego(string vagaId, string cargo, string empresa, string descricao, string endereço, double salario, string data, string telefone, string cidade)
        {
            VagaId = vagaId;
            Cargo = cargo;
            Empresa = empresa;
            Descricao = descricao;
            Endereço = endereço;
            Salario = salario;
            Data = data;
            Telefone = telefone;
            Cidade = cidade;
        }

        public string VagaId { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public string Descricao { get; set; }
        public string Endereço { get; set; }
        public double Salario { get; set; }
        public string Data { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
    }
}
