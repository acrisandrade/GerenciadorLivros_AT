using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio_GerenciadorLivros.Models;
using Microsoft.AspNetCore.Mvc;
using ServicosAplicacao.Servicos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ServicosLivro _livroServicos;

        public LivrosController(ServicosLivro servico)
        {
            _livroServicos = servico;
        }
        [HttpGet]
        public async Task <IEnumerable<Livro>> Get()
        {
            return await _livroServicos.Listar();
        }

        // GET api/<LivrosController>/5
        [HttpGet("{id}")]
        public async Task <Livro> Get(Guid id)
        {
            var livros = await _livroServicos.LivroEspecifico(id);
            return livros;
        }

        // POST api/<LivrosController>
        [HttpPost]
        public async Task<Livro> Post([FromBody] Livro livro)
        {
            var l = await _livroServicos.Cadastrar(livro);
            return l;
        }

        // PUT api/<LivrosController>/5
        [HttpPut("{id}")]
        public async Task<Livro> Put([FromBody]Livro livro)
        {
            var l = await _livroServicos.Editar(livro);
            return l;
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var a = await _livroServicos.Excluir(id);
            return a;
        }
    }
}
