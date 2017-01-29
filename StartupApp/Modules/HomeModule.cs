using System;
using EasyNetQ;
using Nancy;
using StartupApp.Models;

namespace StartupApp.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/", true] = async (x, ct) =>
            {
                var model = new Result();
                try
                {
                    using (var myBus = RabbitHutch.CreateBus("host=rabbitmq"))
                    {
                        if (myBus.IsConnected)
                        {
                            model.RabbitMqState = TestState.Successful;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    model.RabbitMqState = TestState.Failed;
                }

                return View["Home", model];

            };
        }
    }
}
