using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Simpatia.Data.schemas;
using Simpatia.Domain.ApiDto;
using Simpatia.Domain.interfaces;
using Simpatia.Domain.models;

namespace Simpatia.Data.repositories
{
    public class AdocaoRepository : IAdocaoRepository
    {
        private IMongoCollection<AdocaoSchema> _adocao { get; set; }
        public AdocaoRepository(MongoDB mongoDB) =>
            _adocao = mongoDB._database.GetCollection<AdocaoSchema>("Adocao");

        public async Task<Adocao> Inserir(AdocaoDto adocaoDto)
        {
            var adocao = new AdocaoSchema
            {
                AdocaoId = Guid.NewGuid().ToString().ToLower(),
                ImagemId = adocaoDto.ImagemId,
                Tipo = adocaoDto.Tipo,
                Descricao = adocaoDto.Descricao,
                Endereco = adocaoDto.Endereco,
                Data = Convert.ToDateTime(adocaoDto.Data),
                Telefone = adocaoDto.Telefone,
                Cidade = adocaoDto.Cidade
            };

            await _adocao.InsertOneAsync(adocao);
            return adocao.ConverterParaDomain();
        }

        public async Task<IList<Adocao>> ObterAdocoes(DateTime inicio, DateTime fim)
        {
            var adocao = new List<Adocao>();
            var animal = new Adocao();

            await _adocao.AsQueryable()
                .ForEachAsync(a =>
                {
                    if (a.Data >= inicio && a.Data <= fim)
                    {
                        animal = a.ConverterParaDomain();
                        adocao.Add(animal);
                    }
                });
            return adocao;
        }

        public async Task<Adocao> ObterPorId(string id)
        {
            var buscaAdocao =  await _adocao.Find(r => r.AdocaoId.Equals(id)).FirstOrDefaultAsync();
            if (buscaAdocao == null)
                return null;
            return buscaAdocao.ConverterParaDomain();
        }
    }
}
