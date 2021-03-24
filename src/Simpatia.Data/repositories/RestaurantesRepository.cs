using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Simpatia.Data.schemas;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.models;

namespace Simpatia.Data.repositories
{
    public class RestaurantesRepository : IRestaurantesRepository
    {
        private IMongoCollection<RestaurantesSchema>  _restaurantes { get; set; }

        public RestaurantesRepository(MongoDB mongoDB) =>
            _restaurantes = mongoDB._database.GetCollection<RestaurantesSchema>("restaurantes");

       public async Task<Restaurante> Inserir(RestaurantesDto restauranteDto)
        {
            var restaurante = new RestaurantesSchema
            {
                RestauranteId = Guid.NewGuid().ToString().ToLower(),
                ImagemId = restauranteDto.ImagemId,
                Site = restauranteDto.Site,
                Descricao = restauranteDto.Descricao,
                Endereço = restauranteDto.Endereco,
                Data = Convert.ToDateTime(restauranteDto.Data),
                Telefone = restauranteDto.Telefone,
                Cidade = restauranteDto.Cidade
            };

            await _restaurantes.InsertOneAsync(restaurante);
            return restaurante.ConverterParaDomain();
        }

        public async Task<IList<Restaurante>> ObterRestaurantes(DateTime inicio, DateTime fim)
        {
            var restaurantes = new List<Restaurante>();
            await _restaurantes.AsQueryable().ForEachAsync(_ =>
                {
                    if (_.Data >= inicio && _.Data <= fim)
                    {
                        var restaurante = _.ConverterParaDomain();
                        restaurantes.Add(restaurante);
                    }
                });
            return restaurantes;
        }
        public async Task<Restaurante> ObterPorId(string id)
        {
            var buscaRestaurante =  await _restaurantes.Find(r => r.RestauranteId.Equals(id)).FirstOrDefaultAsync();
            if (buscaRestaurante == null)
                return null;
            return buscaRestaurante.ConverterParaDomain();
        }
    }
}
