namespace Simpatia.Domain.models
{
    public class Adocao
    {
        public Adocao() {}
        public Adocao(string adocaoId, string imagemId, string tipo, string descricao, string endereco, string telefone, string cidade, string data)
        {
            AdocaoId = adocaoId;
            ImagemId = imagemId;
            Tipo = tipo;
            Descricao = descricao;
            Endereco = endereco;
            Telefone = telefone;
            Cidade = cidade;
            Data = data;
        }

        public string AdocaoId { get; set; }
        public string ImagemId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Data { get; set; }
    }
}
