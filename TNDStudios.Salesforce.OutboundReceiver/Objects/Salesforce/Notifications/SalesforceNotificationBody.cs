using Newtonsoft.Json;
using System;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceNotificationsBody : JsonBase
    {
        [JsonProperty(PropertyName = "notifications")]
        public SalesforceNotifications Notifications { get; set; }

        public SalesforceNotificationsBody() : base()
        {
            Notifications = new SalesforceNotifications();
        }
    }
}
