using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

namespace BrightPeeps.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                // .ConfigureAppConfiguration((context, config) =>
                // {
                //     if (context.HostingEnvironment.IsDevelopment())
                //     {
                //         var _config = config.Build();
                //         var secretClient = new SecretClient(
                //             vaultUri: new Uri($"https://{_config["KeyVaultName"]}.vault.azure.net"),
                //             credential: new DefaultAzureCredential()
                //         );
                //         config.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());
                //     }
                // })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.AddConsole();
                        // logging.AddAzureWebAppDiagnostics();
                    });
                });
    }
}
