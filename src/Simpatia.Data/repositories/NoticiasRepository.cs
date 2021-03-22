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
    public class NoticiasRepository : INoticiasRepository
    {
        private IMongoCollection<NoticiasSchema>  _Noticias { get; set; }
        public NoticiasRepository(MongoDB mongoDB) =>
            _Noticias = mongoDB._database.GetCollection<NoticiasSchema>("Noticias");
        public async Task<Noticia> Inserir(NoticiaDto noticiaDto)
        {
            var buscaNoticia =  await _Noticias.FindAsync(r => r.NoticiaId.Equals(noticiaDto.NoticiaId));
            var noticia = new NoticiasSchema
            {
                NoticiaId = noticiaDto.NoticiaId.ToString(),
                ImagemId = noticiaDto.ImagemId.ToString(),
                Descricao = noticiaDto.Descricao,
                Data = Convert.ToDateTime(noticiaDto.Data),
                Fonte = noticiaDto.Fonte,
            };
            if (buscaNoticia != null)
            {
                _Noticias.ReplaceOne(e => e.NoticiaId.Equals(noticia.NoticiaId), noticia);
                return noticia.ConverterParaDomain();
            }
            _Noticias.InsertOne(noticia);
            return noticia.ConverterParaDomain();
        }

        public async Task<IList<Noticia>> ObterNoticias()
        {
           var noticias = new List<Noticia>();
            await _Noticias.AsQueryable().ForEachAsync(r =>
                {
                    var noticia = r.ConverterParaDomain();
                    noticias.Add(noticia);
                });
            return noticias;
        }

        public async Task<Noticia> ObterPorId(string id)
        {
            var buscaNoticia =  await _Noticias.Find(r => r.NoticiaId.Equals(id)).FirstOrDefaultAsync();
            if (buscaNoticia == null)
                return null;
            return buscaNoticia.ConverterParaDomain();
        }
    }
}
