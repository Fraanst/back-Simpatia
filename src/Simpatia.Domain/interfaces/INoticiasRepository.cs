using System.Collections.Generic;
using System.Threading.Tasks;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.models;

namespace Simpatia.Domain.interfaces
{
    public interface INoticiasRepository
    {
        Task<Noticia> Inserir(NoticiaDto NoticiaDto);
        Task<IList<Noticia>> ObterNoticias();
        Task<Noticia> ObterPorId(string id);
    }
}
