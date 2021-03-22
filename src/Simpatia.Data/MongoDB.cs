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
                    i.MapIdMember(c => c.AdocaoId);
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
