using System;

namespace Simpatia.Domain.ApiDto
{
    public class NoticiaDto
    {
        public Guid NoticiaId { get; set; }
        public Guid ImagemId { get; set; }
        public string Descricao { get; set; }
        public string Fonte { get; set; }
        public string Origem { get; set; }
        public string Data { get; set; }
    }
}
