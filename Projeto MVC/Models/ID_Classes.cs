using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_MVC.Models
{
    public class ID_Classes
    {   
        public Guid LivrosId { get; set; }
        public Guid AutoresId { get; set; }
        public Livro Livros { get; set; }
        public Autor Autores { get; set; }
        
    }
}
