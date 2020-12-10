using Dominio_GerenciadorLivros.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDB.Data
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ID_Classes>().HasKey(e => new { e.AutoresId, e.LivrosId }).HasName("Chave_p_composta");
            builder.Entity<ID_Classes>().HasOne(e => e.Livros)
                                        .WithMany(b => b.Autores)
                                        .HasForeignKey(b => b.LivrosId);
            builder.Entity<ID_Classes>().HasOne(e => e.Autores)
                                        .WithMany(a => a.Livros)
                                        .HasForeignKey(a => a.AutoresId);

            builder.Entity<Autor>().HasIndex(p => p.Email).IsUnique();

        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<ID_Classes> ID_Classes { get; set; }
    }
}
