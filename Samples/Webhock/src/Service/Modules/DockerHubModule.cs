using System;
using System.IO;
using System.Text;
using Nancy;

namespace FP.Spartakiade2017.Docker.WebHock.Service.Modules
{
    public class DockerHubModule : NancyModule
    {
        public DockerHubModule()
        {
            Post("/dockerhub/", async args =>
            {
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    var contentAsText = await reader.ReadToEndAsync();
                    Console.WriteLine(contentAsText);
                }
                return HttpStatusCode.OK;
            });
        }
    }
}
