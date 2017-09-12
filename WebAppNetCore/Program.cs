using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace WebAppNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // http://kerryritter.com/deploying-asp-net-core-to-heroku/

            var url = $"http://*:{Environment.GetEnvironmentVariable("PORT")}/";

            Console.WriteLine($"Using Url: {url}");

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls(url)
                .Build();

            host.Run();
        }
    }
}
