using Dominio_GerenciadorLivros.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_GerenciadorLivros.ViewModel
{
    public class LivrosViewModel
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set; }
        public IEnumerable<Autor> TodosAutores { get; set; }
    }
}
