using Newtonsoft.Json;
using System;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    public class TestSalesforceObject : SalesforceObjectBase
    {
        [JsonProperty(PropertyName = "sf:email")]
        public String Email { get; set; }

        public TestSalesforceObject() : base()
        {
        }
    }
}
