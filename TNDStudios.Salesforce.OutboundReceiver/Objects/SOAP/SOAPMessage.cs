using Newtonsoft.Json;
using System;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SOAPMessage<T> : JsonBase where T : new()
    {
        [JsonProperty(PropertyName = "soapenv:Envelope")]
        public SOAPEnvelope<T> Envelope { get; set; }

        [JsonProperty(PropertyName = "?xml")]
        public XMLHeader XMLHeader { get; set; }

        public SOAPMessage() : base()
        {
            Envelope = new SOAPEnvelope<T>();
            XMLHeader = new XMLHeader();
        }
    }
}
