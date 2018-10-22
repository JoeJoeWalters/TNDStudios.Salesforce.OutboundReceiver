using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;

namespace TNDStudios.Tools.Soap.Objects
{
    [Serializable]
    [JsonObject]
    public class SoapBase
    {
        [JsonExtensionData]
        public IDictionary<String, Object> PropertyBag =
            new Dictionary<String, Object>();

        public SoapBase()
        {
            PropertyBag = new Dictionary<String, Object>();
        }
    }


}