using Newtonsoft.Json;
using System;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceNotification : SoapBase
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
