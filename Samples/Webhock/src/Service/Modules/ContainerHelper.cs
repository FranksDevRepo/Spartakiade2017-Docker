﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace FP.Spartakiade2017.Docker.WebHock.Service.Modules
{
    public class ContainerHelper : IDisposable
    {
        private DockerClient _client;

        public ContainerHelper(string endpointUrl)
        {
            _client = new DockerClientConfiguration(new Uri(endpointUrl)).CreateClient();
        }

        public async Task PullImage(string owner, string name, string tag)
        {
            var pullParams = new ImagesPullParameters
            {
                Parent = string.IsNullOrEmpty(owner) ? name : $"{owner}/{name}",
                Tag = tag
            };


            var stream = await _client.Images.PullImageAsync(pullParams, null);
            using (var sr = new StreamReader(stream))
            {
                await sr.ReadToEndAsync();
            }
        }

        public async Task StopContainer(string id, CancellationToken token)
        {
            await _client.Containers.StopContainerAsync(id, new ContainerStopParameters(), token);
        }

        public Task DeleteContainer(string containerId)
        {
            return _client.Containers.RemoveContainerAsync(containerId, new ContainerRemoveParameters());
        }

        public async Task<string> StartContainer(string containerName, string owner, string name, string tag)
        {
            var createParam = new CreateContainerParameters();
            if (string.IsNullOrEmpty(owner))
            {
                createParam.Image = $"{name}:{tag}";
            }
            else
            {
                createParam.Image = $"{owner}/{name}:{tag}";
            }
            createParam.Name = name;
            createParam.ExposedPorts = new Dictionary<string, object>();

            var result = await _client.Containers.CreateContainerAsync(createParam);
            if (result.Warnings.Any())
            {
                throw new Exception($"Warning by creating container {containerName} {string.Join("\n", result.Warnings)}");
            }
            else
            {
                await _client.Containers.StartContainerAsync(result.ID, null);
                return result.ID;
            }
        }

        public async Task<string> GetContainerIdByName(string name)
        {
            var listParam = new ContainersListParameters
            {
                Filters = new Dictionary<string, IDictionary<string, bool>>
                {
                    {"name", new Dictionary<string, bool> {{ name, true}}}
                },
                All = true
            };

            var result = await _client.Containers.ListContainersAsync(listParam);
            if (!result.Any())
            {
                return string.Empty;
            }
            else
            {
                return result.First().ID;
            }
        }

       

        public void Dispose()
        {
            _client?.Dispose();
        }


       
    }
}
