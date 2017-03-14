﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FP.Spartakiade2017.Docker.WebHock.Service.Model
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        
        [JsonProperty("repo_name")]
        public string RepoName { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }
    }
}
