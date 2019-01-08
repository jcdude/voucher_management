using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace PTS.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               /*.ConfigureAppConfiguration((hostingContext, config) =>
               {
                   var env = hostingContext.HostingEnvironment;
                   config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                   config.AddEnvironmentVariables();
               })
               .ConfigureLogging((hostingContext, logging) =>
               {
                   logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                   logging.AddConsole();
                   logging.AddDebug();
               })*/
               .ConfigureKestrel((context, options) =>
               {
                   var env = context.HostingEnvironment;
                   if (!env.IsDevelopment())
                   {
                       options.Limits.MaxConcurrentConnections = 100;
                       options.Limits.MaxConcurrentUpgradedConnections = 100;
                       options.Limits.MaxRequestBodySize = 10 * 1024;
                       options.Listen(IPAddress.Loopback, 5000);
                       options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                       {
                           listenOptions.UseHttps("/etc/letsencrypt/live/api.pointtechsol.com/cert.pfx", "certApi");
                       });
                   }
               })
               .UseStartup<Startup>();
    }
}
