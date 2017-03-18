using FP.Spartakiade2017.Docker.Environment.Data;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace FP.Spartakiade2017.Docker.Environment
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            container.Register(new MessageRepository("mongodb://localhost"));
            base.ApplicationStartup(container, pipelines);
        }
    }
}
