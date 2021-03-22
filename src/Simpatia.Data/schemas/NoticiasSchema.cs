using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Simpatia.Domain.models;

namespace Simpatia.Data.schemas
{
    public class NoticiasSchema
    {
     [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string NoticiaId { get; set; }
        public string ImagemId { get; set; }
        public string Descricao { get; set; }
        public string Fonte { get; set; }
        public string Origem { get; set; }
        public DateTime Data { get; set; }
    }
   public static class NoticiasSchemaExtensao
    {
        public static Noticia ConverterParaDomain(this NoticiasSchema documento)
        {
            var noticia = new Noticia(
                documento.NoticiaId,
                documento.ImagemId,
                documento.Descricao,
                documento.Fonte,
                documento.Data.ToString("dd/MM/yyyy HH:mm:ss"));
            return noticia;
        }
    }
}
