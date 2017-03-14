using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FP.Spartakiade2017.Docker.WebHock.Service.Model
{
    public class PushData
    {
        [JsonProperty("pushed_at")]
        public int PushedAt { get; set; }

        [JsonProperty("images")]
        public string[] Images { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("pusher")]
        public string Pusher { get; set; }
    }
}
