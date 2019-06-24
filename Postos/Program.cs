using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Postos.Data;
using Postos.Services;

namespace Postos
{
    public class Program
    {

        public static void Main(string[] args)
        {

            var host = CreateWebHostBuilder(args).Build();
            IDataManager serviceContext;

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                   serviceContext = services.GetRequiredService<IDataManager>();
                   //serviceContext.DownloadFileAsync();

                    Scheduler.IntervalInMinutes(01, 35, 5,() => {
                        Console.WriteLine("Scheduling job...");
                    });
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred.");
                }
            }

            host.Run();
                  
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
