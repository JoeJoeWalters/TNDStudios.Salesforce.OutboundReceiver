using Newtonsoft.Json;
using System;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    /// <summary>
    /// The body of the Soap envelope that we are receiving a message for
    /// </summary>
    /// <typeparam name="T">The type of object we are being notified about</typeparam>
    [Serializable]
    [JsonObject]
    public class SalesforceNotificationsBody<T> : SoapBase 
        where T : SalesforceObjectBase, new()
    {
        /// <summary>
        /// The notifications holding object that contains a list of notifications
        /// </summary>
        [JsonProperty(PropertyName = "notifications")]
        public SalesforceNotifications<T> Notifications { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesforceNotificationsBody() : base()
        {
            Notifications = new SalesforceNotifications<T>();
        }
    }
}
