using System.Collections.Generic;
using System.Threading.Tasks;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.models;

namespace Simpatia.Domain.interfaces
{
    public interface IEventosRepository
    {
        Task<Evento> Inserir(EventosDto eventoDto);
        Task<IList<Evento>> ObterEventos();
        Task<Evento> ObterPorId(string id);
    }
}
