using System;
using System.Collections.Generic;
using System.Linq;
using Aula.API.Models;

namespace Aula.API.Repositories
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        private readonly List<FundoCapital> _storage;   

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }

        public void Adicionar(FundoCapital fundo)
        {
            _storage.Add(fundo);
        }

        public void Alterar(FundoCapital fundo)
        {
            var index = _storage.FindIndex(0, 1, f => f.Id == fundo.Id);

            _storage[index] = fundo;
        }

        public IEnumerable<FundoCapital> ListarFundos()
        {
            return _storage;
        }

        public FundoCapital ObterPorID(Guid id)
        {
            return _storage.FirstOrDefault(f => f.Id == id);
        }

        public void Remover(FundoCapital fundo)
        {
            _storage.Remove(fundo);
        }
    }
}