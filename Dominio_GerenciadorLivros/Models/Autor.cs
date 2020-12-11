using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_GerenciadorLivros.Models
{
    public class Autor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<ID_Classes> Livros { get; set; }
       

        public Autor()
        {
            
            Livros = new List<ID_Classes>();
        }
    }
}
