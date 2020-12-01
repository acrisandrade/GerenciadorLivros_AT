using BancoDB.Repositorios;
using Dominio_GerenciadorLivros.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicosAplicacao.Servicos
{
    public class ServicosAutor
    {
        private AutorRepositorio _repositorioAutores;

        public ServicosAutor(AutorRepositorio autores)
        {
            _repositorioAutores = autores;

        }

        public async Task<Autor> Cadastrar(Autor a)
        {
            try
            {
                a.Id = Guid.NewGuid();
                await _repositorioAutores.Adicionar(a);
            }
             catch (Exception ex)
            {
                throw ex;
            }
            return a;
        }

        public async Task<bool> Excluir(Guid id)
        {
            return await _repositorioAutores.Delete(id);
        }

        public async Task<Autor> Editar(Autor autor)
        {
            return await _repositorioAutores.Editar(autor);
        }

        public async Task<IEnumerable<Autor>> Listar ()
        {
            return await _repositorioAutores.ListarTodos();
        }

        public async Task<Autor> AutorEspecifico(Guid Id)
        {
            return await _repositorioAutores.Detalhes(Id);
        }
    }
}
