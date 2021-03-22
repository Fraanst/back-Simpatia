namespace Simpatia.Domain.models
{
    public class Restaurante
    {
        public Restaurante(string restauranteId, string imagemId, string site, string descricao, string endereco, string data, string telefone, string cidade)
        {
            RestauranteId = restauranteId;
            ImagemId = imagemId;
            Site = site;
            Descricao = descricao;
            Endereco = endereco;
            Data = data;
            Telefone = telefone;
            Cidade = cidade;
        }

        public string RestauranteId { get; set; }
        public string ImagemId { get; set; }
        public string Site { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Data { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
    }
}
