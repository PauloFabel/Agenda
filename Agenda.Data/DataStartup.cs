using Agenda.Data.Context;
using Agenda.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Agenda.Data
{
    public static class DataStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();

            services.AddDbContext<Contexto>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }
             
    }
}
