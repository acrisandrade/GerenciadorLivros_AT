using BancoDB.Data;
using Dominio_GerenciadorLivros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoDB.Repositorios
{
    public class LivroRepositorio
    {
        private readonly Context _context;
        private readonly DbSet<Livro> _Livro;

        public LivroRepositorio(Context context)
        {
            _context = context;
            _Livro = _context.Set<Livro>();
        }

        public async Task<Livro> Adicionar(Livro livro)
        {
            try
            {
                await _Livro.AddAsync(livro);
                await _context.SaveChangesAsync();
                return livro;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Delete(Guid Id)
        {
            var livro = await _Livro.FindAsync(Id);
            if (livro == null)
            {
                return false;
            }
            _Livro.Remove(livro);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Livro> Editar(Livro livro)
        {
            if (livro.Id == null)
            {
                return null;
            }
            try
            {
                _context.Entry(livro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
            return livro;
        }

        public async Task<Livro> Detalhes(Guid id)
        {
            var livro = await _Livro.FindAsync(id);
            
            var a = await _context.Set<Autor>().Include(a => a.Livros).ThenInclude(l => l.Autores).ToListAsync();
            //await _db.Set<Author>().Include(a => a.BooksAuthors).ThenInclude(b => b.Author).ToListAsync();

            if (livro == null)
            {
                return null;
            }
            return livro;
        }

        public async Task<IEnumerable<Livro>> ListarTodos()
        {
            var livros = await _Livro.ToListAsync();
            return livros;

        }
    }
}
