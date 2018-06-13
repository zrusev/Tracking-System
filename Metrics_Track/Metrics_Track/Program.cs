namespace Metrics_Track
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(ConfigConfiguration)
            .UseStartup<Startup>()
            .Build();

        static void ConfigConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);

            //var config = configurationBuilder.Build();

            //configurationBuilder.AddAzureKeyVault(
            //    $"https://{config["KeyVault:vault"]}.vault.azure.net/",
            //    config["KeyVault:clientId"],
            //    config["KeyVault:clientSecret"]
            //);
        }
    }
}
