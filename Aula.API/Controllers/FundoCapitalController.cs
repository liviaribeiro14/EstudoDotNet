using System;
using Aula.API.Models;
using Aula.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aula.API.Controllers {
    public class FundoCapitalController : Controller 
    {

        private readonly IFundoCapitalRepository _repository;

        public FundoCapitalController(IFundoCapitalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos(){
            return Ok(
                _repository.ListarFundos()
            );
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult AdicionarFundo([FromBody]FundoCapital fundo){
            _repository.Adicionar(fundo);
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult AlterarFundo(Guid id, [FromBody]FundoCapital fundo){
            var fundoSalvo = _repository.ObterPorID(id);

            if(fundoSalvo == null)
            {
                return NotFound();
            }

            fundoSalvo.Nome = fundo.Nome;
            fundoSalvo.ValorAtual = fundo.ValorAtual;
            fundoSalvo.ValorNecessario = fundo.ValorNecessario;
            fundoSalvo.DataResgate = fundo.DataResgate;    

            _repository.Alterar(fundoSalvo);
            return Ok();
        }

        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult ObterFundo(Guid id){
            var fundo = _repository.ObterPorID(id);

            if(fundo == null)
            {
                return NotFound();
            }

            return Ok(fundo);
        }

        [HttpDelete("v1/fundocapital/{id}")]
        public IActionResult RemoverFundo(Guid id){
            var fundo = _repository.ObterPorID(id);

            if(fundo == null)
            {
                return NotFound();
            }

            _repository.Remover(fundo);
            return Ok();
        }
    }
}