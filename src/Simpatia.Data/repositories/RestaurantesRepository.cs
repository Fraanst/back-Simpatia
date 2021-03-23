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
            var buscaRestaurante =  await _restaurantes.FindAsync(r => r.RestauranteId.Equals(restauranteDto.RestauranteId));
            var restaurante = new RestaurantesSchema
            {
                RestauranteId = restauranteDto.RestauranteId.ToString(),
                ImagemId = restauranteDto.ImagemId,
                Site = restauranteDto.Site,
                Descricao = restauranteDto.Descricao,
                Endereço = restauranteDto.Endereço,
                Data = Convert.ToDateTime(restauranteDto.Data),
                Telefone = restauranteDto.Telefone,
                Cidade = restauranteDto.Cidade
            };
            if (buscaRestaurante != null)
            {
                _restaurantes.ReplaceOne(e => e.RestauranteId.Equals(restaurante.RestauranteId), restaurante);
                return restaurante.ConverterParaDomain();
            }
            _restaurantes.InsertOne(restaurante);
            return restaurante.ConverterParaDomain();
        }

        public async Task<IList<Restaurante>> ObterRestaurantes(DateTime inicio, DateTime fim)
        {
            var restaurantes = new List<Restaurante>();
            await _restaurantes.AsQueryable().ForEachAsync(r =>
                {
                    var restaurante = r.ConverterParaDomain();
                    restaurantes.Add(restaurante);
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
