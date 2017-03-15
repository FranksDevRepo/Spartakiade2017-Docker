using System.IO;
using FP.Spartakiade2017.Docker.WebHock.Service.Model;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace FP.Spartakiade2017.Docker.WebHock.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseKestrel()
               .UseStartup<Startup>()
               .UseUrls("http://0.0.0.0:4000")
               .Build();

            host.Run();
        }
    }
}
