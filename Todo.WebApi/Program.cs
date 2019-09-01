using System;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ToDo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Any, 5000);
                        options.Listen(IPAddress.Any, 80);
                        var certPath = Environment.GetEnvironmentVariable("CERTIFICATE_PATH");
                        var certPass = Environment.GetEnvironmentVariable("CERTIFICATE_PASS");
                        options.Listen(IPAddress.Any, 443, listenOptions =>
                        {
                            listenOptions.UseHttps(certPath, certPass);
                        });
                    })
                .UseStartup<Startup>()
                .Build();
    }
}
