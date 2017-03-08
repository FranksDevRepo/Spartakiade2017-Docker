using System;

namespace FP.Spartakiade2017.Docker.BuildOutside.WebApp.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get("/", args => $"Hallo Spartakiade - {DateTime.Now}");
        }
    }
}
