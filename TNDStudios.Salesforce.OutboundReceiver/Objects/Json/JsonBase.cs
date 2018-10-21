using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;

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


}