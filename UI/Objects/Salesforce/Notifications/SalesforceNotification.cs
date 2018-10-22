using Newtonsoft.Json;
using System;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceNotification<T> : SoapBase 
        where T : SalesforceObjectBase, new()
    {
        [JsonProperty(PropertyName = "Id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "sObject")]
        public T SalesforceObject { get; set; }

        public SalesforceNotification() : base()
        {
            // Activate a new object of type T as the default
            SalesforceObject = Activator.CreateInstance<T>();
        }
    }
}
