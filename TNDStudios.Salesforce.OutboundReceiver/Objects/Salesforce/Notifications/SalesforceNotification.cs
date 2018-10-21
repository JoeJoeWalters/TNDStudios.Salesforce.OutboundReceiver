using Newtonsoft.Json;
using System;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceNotification : JsonBase
    {
        [JsonProperty(PropertyName = "Id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "sObject")]
        public SalesforceObject SalesforceObject { get; set; }

        public SalesforceNotification() : base()
        {
            SalesforceObject = new SalesforceObject();
        }
    }
}
