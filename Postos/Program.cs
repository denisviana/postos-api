using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Postos
{
    public class Program
    {

        const String URL = "http://www.anp.gov.br/arquivos/dadosabertos/precos/precos-semanais_ultimas-4-semanas_gasolina-etanol.csv";

        public static void Main(string[] args)
        {

            var wc = new System.Net.WebClient();
            Console.WriteLine("Download file...");
            wc.DownloadFile(URL, @"c:\temp\myfile.csv");

            CreateWebHostBuilder(args).Build().Run();
                  
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
