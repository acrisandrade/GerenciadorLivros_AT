using BancoDB.Data;
using BancoDB.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicosAplicacao.InjecaoServicos
{
    public class ConfiguracaoInjecaoRepositorio
    {
        //configuração de inicialização do banco de dados e do repositorio
        //CrossCutting
        public static void ConfigurarRepositorio(IServiceCollection services)
        {
            services.AddDbContext<Context>(
                options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BancoGerenciamentoLivros;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddScoped<AutorRepositorio>();
            services.AddScoped<LivroRepositorio>();
        }
    }
}
