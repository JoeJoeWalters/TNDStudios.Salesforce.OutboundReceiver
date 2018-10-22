using Newtonsoft.Json;
using System;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceNotificationsBody : SoapBase
    {
        [JsonProperty(PropertyName = "notifications")]
        public SalesforceNotifications Notifications { get; set; }

        public SalesforceNotificationsBody() : base()
        {
            Notifications = new SalesforceNotifications();
        }
    }
}
