using Newtonsoft.Json;
using System;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceObjectBase : SoapBase
    {
        [JsonProperty(PropertyName = "@xsi:type")]
        public String ObjectType { get; set; }

        [JsonProperty(PropertyName = "@xmlns:sf")]
        public String Namespace { get; set; }

        [JsonProperty(PropertyName = "sf:id")]
        public String Id { get; set; }

        public SalesforceObjectBase() : base()
        {
        }
    }
}
