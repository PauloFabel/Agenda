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
    }
}
