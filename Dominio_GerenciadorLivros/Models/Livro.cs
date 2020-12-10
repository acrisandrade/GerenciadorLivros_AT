using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio_GerenciadorLivros.Models
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public string Ano { get; set; }
        public List<ID_Classes> Autores { get; set; }

        public Livro()
        {
            Autores = new List<ID_Classes>();
        }
    }
}
