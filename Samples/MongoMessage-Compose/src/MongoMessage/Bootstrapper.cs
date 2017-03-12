using FP.Spartakiade2017.Docker.Compose.Data;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace FP.Spartakiade2017.Docker.Compose
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register(new MessageRepository("mongodb://mymongodb"));
            base.ApplicationStartup(container, pipelines);
        }
    }
}
