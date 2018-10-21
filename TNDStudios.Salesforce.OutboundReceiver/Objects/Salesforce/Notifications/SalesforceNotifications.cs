using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
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
}
