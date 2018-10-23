using Newtonsoft.Json;
using System;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    /// <summary>
    /// Test salesforce object with a few properties to test the mapping
    /// </summary>
    public class TestSalesforceObject : SalesforceObjectBase
    {
        [JsonProperty(PropertyName = "sf:email")]
        public String Email { get; set; }

        public TestSalesforceObject() : base()
        {
        }
    }
}
