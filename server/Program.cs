using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SchoolBook.DataAccessLayer.Interfaces;

namespace SchoolBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost webHost = CreateHostBuilder(args).Build();
            /*app.UseHttpsRedirection();*/
            InitialDbSeed(webHost);

            webHost.Run();
        }

        private static void InitialDbSeed(IWebHost webHost)
        {
            var scopeFactory = webHost.Services
                .GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider
                    .GetService<ISeeder>();
                seeder.Seed().Wait();
            }
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>();

        private static void SetupConfiguration(WebHostBuilderContext ctx,
            IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            builder.AddJsonFile("appsettings.json", false, true);
        }
    }
}
