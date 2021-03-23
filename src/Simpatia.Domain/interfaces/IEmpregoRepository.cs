using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.models;

namespace Simpatia.Domain.interfaces
{
    public interface IEmpregoRepository
    {
        Task<Emprego> Inserir(EmpregoDto empregoDto);
        Task<IList<Emprego>> ObterEmpregos(DateTime inicio, DateTime fim);
        Task<Emprego> ObterPorId(string id);
    }
}
