using Newtonsoft.Json;
using System;

namespace TNDStudios.Salesforce.OutboundReceiver.Objects
{
    [Serializable]
    [JsonObject]
    public class SalesforceObject : JsonBase
    {
        public SalesforceObject() : base()
        {
        }
    }
}
