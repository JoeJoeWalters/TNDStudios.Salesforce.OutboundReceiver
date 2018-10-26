using Newtonsoft.Json;
using System;
using TNDStudios.Data.Repository;
using TNDStudios.Salesforce.OutboundReceiver.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Api.Salesforce.Test.V2
{
    /// <summary>
    /// Test salesforce object with a few properties to test the mapping
    /// </summary>
    public class TestSalesforceObject : SalesforceObjectBase
    {
        [JsonProperty(PropertyName = "sf:email")]
        public String Email { get; set; }

        [JsonProperty(PropertyName = "sf:name")]
        public String Name { get; set; }

        public TestSalesforceObject() : base()
        {
        }
    }
}
