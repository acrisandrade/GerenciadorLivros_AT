using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_MVC.Models
{
    public class ID_Classes
    {
        public Guid Id { get; set;}
        public List<Livro> Livros { get; set; }
        public List<Autor> Autores { get; set; }
        
    }
}
