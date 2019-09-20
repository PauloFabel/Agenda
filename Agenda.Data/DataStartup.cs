using Agenda.Data.Context;
using Agenda.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agenda.Data
{
    public static class DataStartup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddDbContext<Contexto>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
