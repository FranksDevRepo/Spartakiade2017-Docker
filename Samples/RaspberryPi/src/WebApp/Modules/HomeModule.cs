﻿using System;

namespace WebApp.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        public HomeModule()
        {
            Get["/"] = args =>
            {
                return $".net in a box (on arm) \n# {DateTime.Now} \n#  {System.Net.Dns.GetHostName()}";

            };
        }
    }
}
