using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_GerenciadorLivros.Models
{
    public class ID_Classes
    {
        public Guid LivrosId { get; set; }
        public Guid AutoresId { get; set; }
        public Livro Livros { get; set; }
        public Autor Autores { get; set; }
    }
}
