using Newtonsoft.Json;
using System;

namespace TNDStudios.Tools.Soap.Objects
{
    [Serializable]
    [JsonObject]
    public class SoapMessage<T> : SoapBase where T : new()
    {
        [JsonProperty(PropertyName = "soapenv:Envelope")]
        public SoapEnvelope<T> Envelope { get; set; }

        [JsonProperty(PropertyName = "?xml")]
        public SoapXmlHeader XMLHeader { get; set; }

        public SoapMessage() : base()
        {
            Envelope = new SoapEnvelope<T>();
            XMLHeader = new SoapXmlHeader();
        }
    }
}
