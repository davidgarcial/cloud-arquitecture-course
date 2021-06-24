using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFORO255.AZURE.Transaction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
