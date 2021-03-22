namespace Simpatia.Domain.models
{
    public class Noticia
    {
        public Noticia(string idNoticia, string imagemId, string descricao, string fonte, string data)
        {
            IdNoticia = idNoticia;
            ImagemId = imagemId;
            Descricao = descricao;
            Fonte = fonte;
            Data = data;
        }

        public string IdNoticia { get; set; }
        public string ImagemId { get; set; }
        public string Descricao { get; set; }
        public string Fonte { get; set; }
        public string Data { get; set; }
    }
}
