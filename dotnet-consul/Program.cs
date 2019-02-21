using DotnetConsul.Consul;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace DotnetConsul
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(cb =>
            {
                var configuration = cb.Build();
                cb.AddConsul(new[] { configuration.GetValue<Uri>("ConsulUrl") }, configuration.GetValue<string>("ConsulConfigPath"));
            })
            .UseStartup<Startup>();
    }
}
