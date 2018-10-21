using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class XMLHeader : JsonBase
    {
        [JsonProperty(PropertyName = "@version")]
        public String Version { get; set; }

        [JsonProperty(PropertyName = "@encoding")]
        public String Encoding { get; set; }

        public XMLHeader() : base()
        {
        }
    }
}
