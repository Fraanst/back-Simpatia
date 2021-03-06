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
    public class EmpregoRepository : IEmpregoRepository
    {
        private IMongoCollection<EmpregoSchema> _empregos { get; set; }
        public EmpregoRepository(MongoDB mongoDB) =>
            _empregos =  mongoDB._database.GetCollection<EmpregoSchema>("Empregos");

        public async Task<Emprego> Inserir(EmpregoDto empregoDto)
        {
            var emprego = new EmpregoSchema
            {
                VagaId = Guid.NewGuid().ToString().ToLower(),
                Cargo = empregoDto.Cargo,
                Empresa = empregoDto.Empresa,
                Descricao = empregoDto.Descricao,
                Endereço = empregoDto.Endereco,
                Salario = empregoDto.Salario,
                Data = Convert.ToDateTime(empregoDto.Data),
                Telefone = empregoDto.Telefone,
                Cidade = empregoDto.Cidade
            };
            await _empregos.InsertOneAsync(emprego);
            return emprego.ConverterParaDomain();
        }

        public async Task<IList<Emprego>> ObterEmpregos(DateTime inicio, DateTime fim)
        {
           var empregos = new List<Emprego>();
            await _empregos.AsQueryable().ForEachAsync(_ =>
                {
                    if (_.Data >= inicio && _.Data <= fim)
                    {
                        var emprego = _.ConverterParaDomain();
                        empregos.Add(emprego);
                    }
                });
            return empregos;
        }

        public async Task<Emprego> ObterPorId(string id)
        {
            var buscaEmprego =  await _empregos.Find(r => r.VagaId.Equals(id)).FirstOrDefaultAsync();
            if (buscaEmprego == null)
                return null;
            return buscaEmprego.ConverterParaDomain();
        }
    }
}
