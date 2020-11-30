using Projeto_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_MVC.ViewModels
{
    public class LivroViewModel
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set; }
        public IEnumerable<Autor> TodosAutores { get; set; }
    }
}
