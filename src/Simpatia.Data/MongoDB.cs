using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Simpatia.Data.schemas;

namespace Simpatia.Data
{
    public class MongoDB
    {
        public IMongoDatabase _database { get;}
        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var client = new MongoClient(configuration["MONGO_DB"]);
                _database = client.GetDatabase(configuration["MONGO_DB_DATABASE"]);
                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não foi possivel se conectar ao MongoDB", ex);
            }
        }

        private void MapClasses()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(AdocaoSchema)))
            {
                BsonClassMap.RegisterClassMap<AdocaoSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(c => c._id);
                    i.MapMember(c => c.AdocaoId);
                    i.MapMember(c => c.Cidade);
                    i.MapMember(c => c.Descricao);
                    i.MapMember(c => c.Data);
                    i.MapMember(c => c.Endereco);
                    i.MapMember(c => c.Telefone);
                    i.MapMember(c => c.Tipo);
                    i.MapMember(c => c.ImagemId);
                    i.MapMember(c => c.Cidade);
                    i.SetIgnoreExtraElements(true);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(EmpregoSchema)))
            {
                BsonClassMap.RegisterClassMap<EmpregoSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(c => c._id);
                    i.MapMember(c => c.VagaId);
                    i.MapMember(c => c.Cargo);
                    i.MapMember(c => c.Descricao);
                    i.MapMember(c => c.Empresa);
                    i.MapMember(c => c.Cidade);
                    i.MapMember(c => c.Data);
                    i.MapMember(c => c.Telefone);
                    i.MapMember(c => c.Endereço);
                    i.MapMember(c => c.Cidade);
                    i.MapMember(c => c.Salario);
                    i.SetIgnoreExtraElements(true);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(EventosSchema)))
            {
                BsonClassMap.RegisterClassMap<EventosSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(c => c._id);
                    i.MapMember(c => c.EventoId);
                    i.MapMember(c => c.Nome);
                    i.MapMember(c => c.Descricao);
                    i.MapMember(c => c.ImagemId);
                    i.MapMember(c => c.Cidade);
                    i.MapMember(c => c.Data);
                    i.MapMember(c => c.Telefone);
                    i.MapMember(c => c.Site);
                    i.MapMember(c => c.Endereco);
                    i.MapMember(c => c.Cidade);
                    i.SetIgnoreExtraElements(true);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(NoticiasSchema)))
            {
                BsonClassMap.RegisterClassMap<NoticiasSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(c => c._id);
                    i.MapMember(c => c.NoticiaId);
                    i.MapMember(c => c.Descricao);
                    i.MapMember(c => c.ImagemId);
                    i.MapMember(c => c.Data);
                    i.MapMember(c => c.Fonte);
                    i.MapMember(c => c.Origem);
                    i.SetIgnoreExtraElements(true);
                });
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(RestaurantesSchema)))
            {
                BsonClassMap.RegisterClassMap<RestaurantesSchema>(i =>
                {
                    i.AutoMap();
                    i.MapIdMember(c => c._id);
                    i.MapMember(c => c.RestauranteId);
                    i.MapMember(c => c.Descricao);
                    i.MapMember(c => c.ImagemId);
                    i.MapMember(c => c.Data);
                    i.MapMember(c => c.Site);
                    i.MapMember(c => c.Telefone);
                    i.MapMember(c => c.Cidade);
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
