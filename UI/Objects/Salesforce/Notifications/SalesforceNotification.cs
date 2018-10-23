using Newtonsoft.Json;
using System;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    /// <summary>
    /// Notification object passed via a SOAP request and of a given type
    /// </summary>
    /// <typeparam name="T">The object type used for this notification</typeparam>
    [Serializable]
    [JsonObject]
    public class SalesforceNotification<T> : SoapBase 
        where T : SalesforceObjectBase, new()
    {
        /// <summary>
        /// The salesforce object id for this notification
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public String Id { get; set; }

        /// <summary>
        /// The object that we are being notified about
        /// </summary>
        [JsonProperty(PropertyName = "sObject")]
        public T SalesforceObject { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesforceNotification() : base()
        {
            // Activate a new object of type T as the default
            SalesforceObject = Activator.CreateInstance<T>();
        }
    }
}
