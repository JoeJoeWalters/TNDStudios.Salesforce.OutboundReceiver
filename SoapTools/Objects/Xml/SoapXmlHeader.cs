using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNDStudios.Tools.Soap.Objects
{
    [Serializable]
    [JsonObject]
    public class SoapXmlHeader : SoapBase
    {
        [JsonProperty(PropertyName = "@version")]
        public String Version { get; set; }

        [JsonProperty(PropertyName = "@encoding")]
        public String Encoding { get; set; }

        public SoapXmlHeader() : base()
        {
        }
    }
}
