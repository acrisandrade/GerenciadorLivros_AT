using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_MVC.Models;

namespace Projeto_MVC.Data
{   
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ID_Classes>().HasKey(e => new { e.AutoresId , e.LivrosId }).HasName("Chave_p_composta");
            builder.Entity<Autor>().HasIndex(p => p.Email).IsUnique();

        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
    }
}
