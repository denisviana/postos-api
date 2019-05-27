using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Postos.Data;
using Postos.Services;

namespace Postos
{
    public class Program
    {

        public static void Main(string[] args)
        {

            DataManager.getInstance().DownloadFileAsync();

            Scheduler.IntervalInMinutes(16, 9, 10,
            () => {
                Console.WriteLine("Scheduling job...");
                
            });

            CreateWebHostBuilder(args).Build().Run();
                  
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
