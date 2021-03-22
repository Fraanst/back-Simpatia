using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Simpatia.Domain.models;

namespace Simpatia.Data.schemas
{
    public class AdocaoSchema
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string AdocaoId { get; set; }
        public string ImagemId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public DateTime Data { get; set; }
    }
    public static class AdocaoSchemaExtensao
    {
        public static Adocao ConverterParaDomain(this AdocaoSchema documento)
        {
            var restaurante = new Adocao(
                documento.AdocaoId,
                documento.ImagemId,
                documento.Tipo,
                documento.Descricao,
                documento.Endereco,
                documento.Telefone,
                documento.Cidade,
                documento.Data.ToString("dd/MM/yyyy HH:mm:ss"));
            return restaurante;
        }
    }
}
