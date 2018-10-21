using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class JsonBase
    {
        [JsonExtensionData]
        public IDictionary<String, Object> PropertyBag =
            new Dictionary<String, Object>();

        public JsonBase()
        {
            PropertyBag = new Dictionary<String, Object>();
        }
    }

    [Serializable]
    [JsonObject]
    public class SalesforceObject : JsonBase
    {
        public SalesforceObject() : base()
        {
        }
    }

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

    [Serializable]
    [JsonObject]
    public class SalesforceNotifications : JsonBase
    {
        [JsonProperty(PropertyName = "OrganizationId")]
        public String OrganizationId { get; set; }

        [JsonProperty(PropertyName = "ActionId")]
        public String ActionId { get; set; }

        [JsonProperty(PropertyName = "SessionId")]
        public String SessionId { get; set; }

        [JsonProperty(PropertyName = "EnterpriseUrl")]
        public String EnterpriseUrl { get; set; }

        [JsonProperty(PropertyName = "PartnerUrl")]
        public String PartnerUrl { get; set; }

        [JsonProperty(PropertyName = "Notification")]
        public List<SalesforceNotification> Items { get; set; }

        public SalesforceNotifications() : base()
        {
            Items = new List<SalesforceNotification>();
        }
    }

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

    [Serializable]
    [JsonObject]
    public class SOAPEnvelope<T> : JsonBase where T : JsonBase, new()
    {
        [JsonProperty(PropertyName = "soapenv:body")]
        public T Body { get; set; }

        [JsonProperty(PropertyName = "@xmlns:soapenv")]
        public String Namespace { get; set; }

        [JsonProperty(PropertyName = "@xmlns:xsd")]
        public String Xsd { get; set; }

        [JsonProperty(PropertyName = "@xmlns:xsi")]
        public String Xsi { get; set; }

        public SOAPEnvelope() : base()
        {
        }
    }

    [Serializable]
    [JsonObject]
    public class XMLHeader : JsonBase
    {
        [JsonProperty(PropertyName = "@version")]
        public String Version { get; set; }

        [JsonProperty(PropertyName = "@encoding")]
        public String Encoding { get; set; }

        public XMLHeader() : base()
        {
        }
    }

    [Serializable]
    [JsonObject]
    public class SOAPMessage<T> : JsonBase where T : JsonBase, new()
    {
        [JsonProperty(PropertyName = "soapenv:Envelope")]
        public SOAPEnvelope<T> Envelope { get; set; }

        [JsonProperty(PropertyName = "?xml")]
        public XMLHeader XMLHeader { get; set; }

        public SOAPMessage() : base()
        {
            Envelope = new SOAPEnvelope<T>();
            XMLHeader = new XMLHeader();
        }
    }
}
