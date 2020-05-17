using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace projetowebapi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //   var host = new WebHostBuilder()
            //     .UseKestrel()
            //     .UseUrls("http://*:5000")
            //     .UseContentRoot(Directory.GetCurrentDirectory())
            //    // .UseIISIntegration()
            //     .UseStartup<Startup>()
            //   //  .UseApplicationInsights()
            //     .Build();
            // host.Run();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
