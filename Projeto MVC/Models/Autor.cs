using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_MVC.Models
{
    public class Autor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome  { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Livro> Livros { get; set;}
    }
}
