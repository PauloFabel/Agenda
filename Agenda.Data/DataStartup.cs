using Agenda.Data.Context;
using Agenda.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;

namespace Agenda.Data
{
    public static class DataStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath("C:\\Users\\paulo\\source\\repos\\Agenda\\Agenda.Api")
            .AddJsonFile("appsettings.json")
            .Build();
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            //services.AddDbContext<Contexto>(i =>
            //{
            //    i.

            //});
        }

        //protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //        .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //    
        //}
    }
}
