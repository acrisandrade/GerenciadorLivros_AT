using BancoDB.Repositorios;
using Dominio_GerenciadorLivros.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServicosAplicacao.Servicos
{
    public class ServicosLivro
    {
        private LivroRepositorio _livroRepositorio;

        public ServicosLivro(LivroRepositorio livros)
        {
            _livroRepositorio = livros;
        }

        public async Task<Livro> Cadastrar(Livro livro)
        {
            try
            {
                livro.Id = Guid.NewGuid();
                await _livroRepositorio.Adicionar(livro);
            }
            catch(Exception e)
            {
                throw e;
            }
            return livro;
        }

        public async Task<bool> Excluir(Guid id)
        {
            return await _livroRepositorio.Delete(id);
        }

        public async Task<Livro> Editar(Livro livro)
        {
            return await _livroRepositorio.Editar(livro);
        }

        public async Task<IEnumerable<Livro>> Listar()
        {
            return await _livroRepositorio.ListarTodos();
        }

        public async Task<Livro> LivroEspecifico(Guid id)
        {
            return await _livroRepositorio.Detalhes(id);
        }
    }
}
