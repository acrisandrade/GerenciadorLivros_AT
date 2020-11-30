using BancoDB.Data;
using Dominio_GerenciadorLivros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BancoDB.Repositorios
{
    public class AutorRepositorio
    {
        private readonly Context _context;
        private readonly DbSet<Autor> _autor;

        public AutorRepositorio(Context context)
        {
            _context = context;
            _autor = _context.Set<Autor>();
        }

        public async Task<Autor> Adicionar(Autor a)
        {
            try
            {
                await _autor.AddAsync(a);
                await _context.SaveChangesAsync();
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete (Guid Id)
        {
            
            var autor = await _autor.FindAsync(Id);
            if (autor == null)
            {
                return false;
            }
            _autor.Remove(autor);
            await _context.SaveChangesAsync();
            return true;
        } 

        public async Task<Autor> Editar(Autor autor)
        {
            if(autor.Id == null)
            {
                return null;
            }
            try
            {
                _context.Entry(autor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception a)
            {
                throw a;
            }
            return autor;
        }
    }
}
