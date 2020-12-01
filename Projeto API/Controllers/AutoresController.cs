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
    public class AutoresController : ControllerBase
    {
        private readonly ServicosAutor _autorServicos;
        public AutoresController( ServicosAutor servico)
        {
            _autorServicos = servico;
        }
        // GET: api/<AutoresController>
        [HttpGet]
        public async Task <IEnumerable<Autor>> Get()
        {
            return await _autorServicos.Listar();
        }

        // GET api/<AutoresController>/5
        [HttpGet("{id}")]
        public async Task<Autor> Get(Guid id)
        {
            var autores = await _autorServicos.AutorEspecifico(id);
            return autores;

        }

        // POST api/<AutoresController>
        [HttpPost]
        public async Task<Autor> Post([FromBody] Autor autor)
        {
            var r = await _autorServicos.Cadastrar(autor);
            return r;
        }

        // PUT api/<AutoresController>/5
        [HttpPut]
        public async Task<Autor> Put(Autor autor)
        {
            var r = await _autorServicos.Editar(autor);
            return r;

        }

        // DELETE api/<AutoresController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var a = await _autorServicos.Excluir(id);
            return a;

        }
    }
}
