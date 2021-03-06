using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.models;

namespace Simpatia.Domain.interfaces
{
    public interface IRestaurantesRepository
    {
        Task<Restaurante> Inserir(RestaurantesDto restauranteDto);
        Task<IList<Restaurante>> ObterRestaurantes(DateTime inicio, DateTime fim);
        Task<Restaurante> ObterPorId(string id);
    }
}
