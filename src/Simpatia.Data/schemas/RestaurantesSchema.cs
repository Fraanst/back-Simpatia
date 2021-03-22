using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Simpatia.Domain.models;

namespace Simpatia.Data.schemas
{
    public class RestaurantesSchema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string RestauranteId { get; set; }
        public string ImagemId { get; set; }
        public string Site { get; set; }
        public string Descricao { get; set; }
        public string Endereço { get; set; }
        public DateTime Data { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }

    }
    public static class RestauranteSchemaExtensao
    {
        public static Restaurante ConverterParaDomain(this RestaurantesSchema documento)
        {
            var restaurante = new Restaurante(
                documento.RestauranteId,
                documento.ImagemId,
                documento.Site,
                documento.Descricao,
                documento.Endereço,
                documento.Data.ToString("dd/MM/yyyy HH:mm:ss"),
                documento.Telefone,
                documento.Cidade);
            return restaurante;
        }
    }
}
