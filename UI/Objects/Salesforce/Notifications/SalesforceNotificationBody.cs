using Newtonsoft.Json;
using System;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceNotificationsBody<T> : SoapBase 
        where T : SalesforceObjectBase, new()
    {
        [JsonProperty(PropertyName = "notifications")]
        public SalesforceNotifications<T> Notifications { get; set; }

        public SalesforceNotificationsBody() : base()
        {
            Notifications = new SalesforceNotifications<T>();
        }
    }
}
