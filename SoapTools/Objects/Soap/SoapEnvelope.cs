using Newtonsoft.Json;
using System;

namespace TNDStudios.Tools.Soap.Objects
{
    [Serializable]
    [JsonObject]
    public class SoapEnvelope<T> : SoapBase where T : new()
    {
        [JsonProperty(PropertyName = "soapenv:body")]
        public T Body { get; set; }

        [JsonProperty(PropertyName = "@xmlns:soapenv")]
        public String Namespace { get; set; }

        [JsonProperty(PropertyName = "@xmlns:xsd")]
        public String Xsd { get; set; }

        [JsonProperty(PropertyName = "@xmlns:xsi")]
        public String Xsi { get; set; }

        public SoapEnvelope() : base()
        {
        }
    }
}
