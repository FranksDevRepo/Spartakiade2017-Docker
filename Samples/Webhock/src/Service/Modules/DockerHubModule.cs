using System;
using System.IO;
using System.Text;
using FP.Spartakiade2017.Docker.WebHock.Service.Model;
using Nancy;
using Newtonsoft.Json;

namespace FP.Spartakiade2017.Docker.WebHock.Service.Modules
{
    public class DockerHubModule : NancyModule
    {
        public DockerHubModule()
        {
            Post("/dockerhub/{appkey}", async (ctx, ct) =>
            {
                if(!string.Equals(ctx.appkey, EnvironmentVariable.GetValueOrDefault("appkey", "topsecret"), StringComparison.CurrentCultureIgnoreCase))
                {
                    return HttpStatusCode.Unauthorized;
                }

                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    var contentAsText = await reader.ReadToEndAsync();
                    var webhock = JsonConvert.DeserializeObject<DockerhubWebhock>(contentAsText);
                    if (!string.Equals(webhock.PushData.Tag, EnvironmentVariable.GetValue("tag")) ||
                        !string.Equals(webhock.Repository.Owner, EnvironmentVariable.GetValue("owner")) ||
                        string.Equals(webhock.Repository.Name, EnvironmentVariable.GetValue("imagename")))
                    {
                        return HttpStatusCode.BadRequest;
                    }

                    string containerName = EnvironmentVariable.GetValue("containername");

                    var helper = new ContainerHelper(EnvironmentVariable.GetValueOrDefault("endpointUrl", "unix://var/run/docker.sock"));
                    await helper.PullImage(webhock.Repository.Owner, webhock.Repository.Name, webhock.PushData.Tag);
                    var containerId = await helper.GetContainerIdByName(containerName);
                    if (!string.IsNullOrEmpty(containerId))
                    {
                        await helper.StopContainer(containerId, ct);
                        await helper.DeleteContainer(containerId);
                    }
                    await helper.StartContainer(containerName, webhock.Repository.Owner, webhock.Repository.Name, webhock.PushData.Tag);





                }
                return HttpStatusCode.OK;
            });
        }
    }
}
