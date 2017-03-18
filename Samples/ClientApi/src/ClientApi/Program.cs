using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace FP.Spartakiade2017.Docker.ClientApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                

                //ListImages(client).Wait();
                //client.Images.SearchImagesAsync(new ImagesSearchParameters {})
                //PullImage(client).Wait();
               // StartContainer(client).Wait();
              //  StopContainer(client).Wait();



                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

       


        private static async Task ListImages(DockerClient client)
        {
            
            

        }

        private static async Task PullImage(DockerClient client)
        {
        }

        private static async Task StartContainer(DockerClient client)
        {
        }

        private static async Task StopContainer(DockerClient client)
        {

        }
    }
}
