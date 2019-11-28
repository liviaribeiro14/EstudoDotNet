using System;
using System.Collections.Generic;
using Aula.API.Models;

namespace Aula.API.Repositories
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapital fundo);
        void Alterar(FundoCapital fundo);
        IEnumerable<FundoCapital> ListarFundos();
        FundoCapital ObterPorID(Guid id);
        void Remover(FundoCapital fundo);
    }
}