using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDB.Data
{
    public class ContextFabrica : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var stringDeConexao = "Server=(localdb)\\mssqllocaldb;Database=BancoGerenciamentoLivros;Trusted_Connection=True;MultipleActiveResultSets=true";
            var opcoesDeConstrucao = new DbContextOptionsBuilder<Context>();
            opcoesDeConstrucao.UseSqlServer(stringDeConexao);
            return new Context(opcoesDeConstrucao.Options);
        }
    }
}
