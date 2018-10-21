using Newtonsoft.Json;
using System;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SOAPEnvelope<T> : JsonBase where T : new()
    {
        [JsonProperty(PropertyName = "soapenv:body")]
        public T Body { get; set; }

        [JsonProperty(PropertyName = "@xmlns:soapenv")]
        public String Namespace { get; set; }

        [JsonProperty(PropertyName = "@xmlns:xsd")]
        public String Xsd { get; set; }

        [JsonProperty(PropertyName = "@xmlns:xsi")]
        public String Xsi { get; set; }

        public SOAPEnvelope() : base()
        {
        }
    }
}
