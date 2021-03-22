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
            var buscaEmprego =  await _empregos.Find(r => r.VagaId.Equals(empregoDto.VagaId)).FirstOrDefaultAsync();
            var emprego = new EmpregoSchema
            {
                VagaId = empregoDto.VagaId.ToString(),
                Cargo = empregoDto.Cargo,
                Empresa = empregoDto.Empresa,
                Descricao = empregoDto.Descricao,
                Endereço = empregoDto.Endereco,
                Salario = empregoDto.Salario,
                Data = Convert.ToDateTime(empregoDto.Data),
                Telefone = empregoDto.Telefone,
                Cidade = empregoDto.Cidade
            };
            if (buscaEmprego != null)
            {
                _empregos.ReplaceOne(e => e.VagaId.Equals(emprego.VagaId), emprego);
                return emprego.ConverterParaDomain();
            }
            _empregos.InsertOne(emprego);
            return emprego.ConverterParaDomain();
        }

        public async Task<IList<Emprego>> ObterEmpregos()
        {
           var empregos = new List<Emprego>();
            await _empregos.AsQueryable().ForEachAsync(r =>
                {
                    var emprego = r.ConverterParaDomain();
                    empregos.Add(emprego);
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
