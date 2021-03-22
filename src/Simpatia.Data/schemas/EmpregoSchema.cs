using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Simpatia.Domain.models;

namespace Simpatia.Data.schemas
{
    public class EmpregoSchema
    {
     [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }
        public string VagaId { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public string Descricao { get; set; }
        public string Endereço { get; set; }
        public double Salario { get; set; }
        public DateTime Data { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
    }
    public static class EmpregoSchemaExtensao
    {
        public static Emprego ConverterParaDomain(this EmpregoSchema documento)
        {
            var restaurante = new Emprego(
                documento.VagaId,
                documento.Cargo,
                documento.Empresa,
                documento.Descricao,
                documento.Endereço,
                documento.Salario,
                documento.Data.ToString("dd/MM/yyyy HH:mm:ss"),
                documento.Telefone,
                documento.Cidade);
            return restaurante;
        }
    }
}
