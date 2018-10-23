using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    /// <summary>
    /// The notifications holding object indicating where the notifications came from
    /// </summary>
    /// <typeparam name="T">The object type that we are being notified about</typeparam>
    [Serializable]
    [JsonObject]
    public class SalesforceNotifications<T> : SoapBase 
        where T : SalesforceObjectBase, new()
    {
        /// <summary>
        /// Reference to the organisation id in Salesforce
        /// </summary>
        [JsonProperty(PropertyName = "OrganizationId")]
        public String OrganizationId { get; set; }

        /// <summary>
        /// What action was being triggered in Salesforce
        /// </summary>
        [JsonProperty(PropertyName = "ActionId")]
        public String ActionId { get; set; }

        /// <summary>
        /// The session that triggered the outbound message in Salesforce
        /// </summary>
        [JsonProperty(PropertyName = "SessionId")]
        public String SessionId { get; set; }

        /// <summary>
        /// The callback Url (1)
        /// </summary>
        [JsonProperty(PropertyName = "EnterpriseUrl")]
        public String EnterpriseUrl { get; set; }

        /// <summary>
        /// THe callback Url (2)
        /// </summary>
        [JsonProperty(PropertyName = "PartnerUrl")]
        public String PartnerUrl { get; set; }

        /// <summary>
        /// List of notification object wrappers of 
        /// type T (The object type being notified)
        /// </summary>
        [JsonProperty(PropertyName = "Notification")]
        public List<SalesforceNotification<T>> Items { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesforceNotifications() : base()
        {
            Items = new List<SalesforceNotification<T>>();
        }
    }
}
