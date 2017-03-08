using System;

namespace FP.Spartakiade2017.Docker.BuildInside.WebApp.Module
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", args => $"Hallo Spartakiade - {DateTime.Now}");
        }
    }
}
