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
    public class AdocaoRepository : IAdocaoRepository
    {
             private IMongoCollection<AdocaoSchema> _adocao { get; set; }
        public AdocaoRepository(MongoDB mongoDB) =>
            _adocao = mongoDB._database.GetCollection<AdocaoSchema>("Adocao");

        public async Task<Adocao> Inserir(AdocaoDto adocaoDto)
        {
            var buscaEmprego =  await _adocao.Find(r => r.AdocaoId.Equals(adocaoDto.AdocaoId)).FirstOrDefaultAsync();
            var adocao = new AdocaoSchema
            {
                AdocaoId = adocaoDto.AdocaoId.ToString(),
                ImagemId = adocaoDto.ImagemId,
                Tipo = adocaoDto.Tipo,
                Descricao = adocaoDto.Descricao,
                Endereco = adocaoDto.Endereco,
                Data = Convert.ToDateTime(adocaoDto.Data),
                Telefone = adocaoDto.Telefone,
                Cidade = adocaoDto.Cidade
            };
            if (buscaEmprego != null)
            {
                _adocao.ReplaceOne(e => e.AdocaoId.Equals(adocao.AdocaoId), adocao);
                return adocao.ConverterParaDomain();
            }
            _adocao.InsertOne(adocao);
            return adocao.ConverterParaDomain();
        }

        public async Task<IList<Adocao>> ObterAdocoes(DateTime inicio, DateTime fim)
        {
           var adocao = new List<Adocao>();
            await _adocao.AsQueryable().ForEachAsync(r =>
                {
                    var animal = r.ConverterParaDomain();
                    adocao.Add(animal);
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
