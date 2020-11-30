using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_MVC.Models
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set;}
        public List<ID_Classes> Autores { get; set; }
    }
}
