using Newtonsoft.Json;
using System;
using TNDStudios.Data.Repository;
using TNDStudios.Salesforce.OutboundReceiver.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Api.Salesforce.Test.V1
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
