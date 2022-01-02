using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Conbot
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("prefix")]
        public string prefix { get; set; }
    }
}
