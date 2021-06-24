using AFORO255.AZURE.Security.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace AFORO255.AZURE.Security
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SecurityContext>();
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    UserRepository.Execute(context, userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((host, config) =>
                    {
                        var settings = config.Build();
                        //config.AddAzureAppConfiguration(settings["CloudConfig:Url"]);
                        config.AddAzureAppConfiguration(options =>
                        {
                            options.Connect(settings["CloudConfig:Url"])
                            .ConfigureRefresh(refresh =>
                            {
                                refresh.Register("Version", true)
                                   .SetCacheExpiration(TimeSpan.FromSeconds(5));
                            });
                        });

                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
