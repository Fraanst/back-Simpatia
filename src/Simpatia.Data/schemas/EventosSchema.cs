using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Simpatia.Domain.models;

namespace Simpatia.Data.schemas
{
    public class EventosSchema
   {
     [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string EventoId { get; set; }
        public string ImagemId { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public DateTime Data { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
    }
    public static class EventosSchemaExtensao
    {
        public static Evento ConverterParaDomain(this EventosSchema documento)
        {
            var restaurante = new Evento(
                documento.EventoId,
                documento.ImagemId,
                documento.Descricao,
                documento.Telefone,
                documento.Site,
                documento.Data.ToString("dd/MM/yyyy HH:mm:ss"),
                documento.Endereco,
                documento.Cidade);
            return restaurante;
        }
    }
}
