using System.Collections.Generic;
using System.Threading.Tasks;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.models;

namespace Simpatia.Domain.interfaces
{
    public interface IAdocaoRepository
    {
        Task<Adocao> Inserir(AdocaoDto adocaoDto);
        Task<IList<Adocao>> ObterAdocoes();
        Task<Adocao> ObterPorId(string id);
    }
}
