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
    public class EventosRepository : IEventosRepository
    {
        private IMongoCollection<EventosSchema>  _eventos { get; set; }
        public EventosRepository(MongoDB mongoDB) =>
            _eventos = mongoDB._database.GetCollection<EventosSchema>("Eventos");

       public async Task<Evento> Inserir(EventosDto eventoDto)
        {
            var buscaEvento =  await _eventos.FindAsync(r => r.EventoId.Equals(eventoDto.EventoId));
            var evento = new EventosSchema
            {
                EventoId = Guid.NewGuid().ToString().ToLower(),
                ImagemId = eventoDto.ImagemId,
                Site = eventoDto.Site,
                Descricao = eventoDto.Descricao,
                Endereco = eventoDto.Endereco,
                Data = Convert.ToDateTime(eventoDto.Data),
                Telefone = eventoDto.Telefone,
                Cidade = eventoDto.Cidade
            };
            await _eventos.InsertOneAsync(evento);
            return evento.ConverterParaDomain();
        }

        public async Task<IList<Evento>> ObterEventos(DateTime inicio, DateTime fim)
        {
            var eventos = new List<Evento>();
            await _eventos.AsQueryable().ForEachAsync(_ =>
                {
                    if (_.Data >= inicio && _.Data <= fim)
                    {
                        var evento = _.ConverterParaDomain();
                        eventos.Add(evento);
                    }
                });
            return eventos;
        }
        public async Task<Evento> ObterPorId(string id)
        {
            var buscaEvento =  await _eventos.Find(r => r.EventoId.Equals(id)).FirstOrDefaultAsync();
            if (buscaEvento == null)
                return null;
            return buscaEvento.ConverterParaDomain();
        }
    }
}
