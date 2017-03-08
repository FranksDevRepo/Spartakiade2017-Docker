using System.IO;

namespace FP.Spartakiade2017.Docker.BuildInside.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseKestrel()
               .UseStartup<Startup>()
               .UseUrls("http://0.0.0.0:5000")
               .Build();

            host.Run();
        }
    }
}
