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
    public class OutboundMessage
    {
        [JsonExtensionData]
        public IDictionary<String, Object> PropertyBag = 
            new Dictionary<String, Object>();

        public OutboundMessage()
        {
            PropertyBag = new Dictionary<String, Object>();
        }
    }
}
