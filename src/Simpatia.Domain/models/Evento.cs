namespace Simpatia.Domain.models
{
    public class Evento
    {
        public Evento(string eventoId, string nome, string imagemId, string descricao, string telefone, string site, string data, string endereco, string cidade)
        {
            Nome = nome;
            EventoId = eventoId;
            ImagemId = imagemId;
            Descricao = descricao;
            Telefone = telefone;
            Site = site;
            Data = data;
            Endereco = endereco;
            Cidade = cidade;
        }

        public string EventoId { get; set; }
        public string Nome { get; set; }
        public string ImagemId { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public string Data { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
    }
}
