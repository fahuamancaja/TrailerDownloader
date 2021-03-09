using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using TrailerDownloader.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TrailerDownloader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            // var host = CreateHostBuilder(args).Build();
            // using var scope = host.Services.CreateScope();
            // var services = scope.ServiceProvider;
            // try
            // {
            //     var context = services.GetRequiredService<MovieDbContext>();
            //     await context.Database.MigrateAsync();
            // }
            // catch (Exception ex)
            // {
            //     var logger = services.GetRequiredService<ILogger<Program>>();
            //     logger.LogError(ex, "An error occurred during migration");
            // }
            // await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
