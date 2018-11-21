using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using TekeriumCommerce.Module.Core.Extensions;

namespace TekeriumCommerce.WebHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostAndBuild(args).Run();
        }

        private static IWebHost CreateWebHostAndBuild(string[] args) =>
            Microsoft.AspNetCore.WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureLogging(SetupLogging)
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext hostingContext, IConfigurationBuilder configBuilder)
        {
            var env = hostingContext.HostingEnvironment; // no need still

            var configuration = configBuilder.Build();

            // done! TODO:
            // EntityFrameworkConfig method is helper method and add it to 
            // Extension folder in TekeriumCommerce.Infrastructure project on further
            // configBuilder.AddEntityFrameworkConfig(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection") });

            configBuilder.AddEntityFrameworkConfig(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // done! todo: after adding Serilog package configure it here
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }

        private static void SetupLogging(WebHostBuilderContext hostingContext, ILoggingBuilder loggingBuilder)
        {
            // done! todo: add serial log
            loggingBuilder.AddSerilog();
        }
    }
}
