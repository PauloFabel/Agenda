using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Agenda.Api;

namespace Sample.Teste
{
    public class BaseTest
    {
        static BaseTest()
        {
            ConfigureService();
        }

        protected static ServiceProvider Provider { get; private set; }

        private static void ConfigureService()
        {
            var services = new ServiceCollection();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var startup = new Startup(config);

            startup.ConfigureServices(services);

            Provider = services.BuildServiceProvider();
        }

        
        protected T GetService<T>()
        {
            return Provider.GetService<T>();
        }
    }
}
