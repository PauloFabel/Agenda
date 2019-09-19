using Agenda.Data.Context;
using Agenda.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Data
{
    public static class DataStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddDbContext<Contexto>(i =>
            {
                //Pesquisa sobre isso
            });
        }

        //protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //}
    }
}
