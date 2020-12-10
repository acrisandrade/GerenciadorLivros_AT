using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio_GerenciadorLivros.Models;
using Dominio_GerenciadorLivros.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicosAplicacao.Servicos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projeto_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LivrosController : ControllerBase
    {
        private readonly ServicosLivro _livroServicos;
        private readonly ServicosAutor _servicosAutor;

        public LivrosController(ServicosLivro livroServicos, ServicosAutor servicosAutor)
        {
            _livroServicos = livroServicos;
            _servicosAutor = servicosAutor;
        }

        [HttpGet]
        public async Task <IEnumerable<Livro>> Get()
        {
            return await _livroServicos.Listar();
        }

        // GET api/<LivrosController>/5
        [HttpGet("{id}")]
        public async Task <LivrosViewModel> Get(Guid id)
        {
            var livro = await _livroServicos.LivroEspecifico(id);
            var autores = new List<Autor>();
            foreach(var a in livro.Autores)
            {
                autores.Add(a.Autores);
            }
            
            var viewLivro = new LivrosViewModel()
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                ISBN = livro.ISBN,
                Ano = livro.Ano,
                TodosAutores = autores,
            };
            return viewLivro;
        }

        // POST api/<LivrosController>
        [HttpPost]
        public async Task<Livro> Post(Livro livro)
        {
            var l = await _livroServicos.Cadastrar(livro);
            return l;
        }

        // PUT api/<LivrosController>/5
        [HttpPut]
        public async Task<Livro> Put([FromForm]Livro livro)
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
