using System;

namespace Simpatia.Domain.ApiDto
{
    public class EmpregoDto
    {
        public Guid VagaId { get; set; }
        public string Cargo { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Empresa { get; set; }
        public string Data { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public double Salario { get; set; }
    }
}
