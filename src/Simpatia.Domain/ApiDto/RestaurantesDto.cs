using System;

namespace Simpatia.Domain.ApiDto
{
    public class RestaurantesDto
    {
        public Guid RestauranteId { get; set; }
        public string ImagemId { get; set; }
        public string Site { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Salario { get; set; }
        public string Data { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
    }
}
