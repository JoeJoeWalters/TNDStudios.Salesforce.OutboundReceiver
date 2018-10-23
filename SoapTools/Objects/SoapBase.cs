using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using TNDStudios.Tools.Json.Objects;

namespace TNDStudios.Tools.Soap.Objects
{
    /// <summary>
    /// Base class to handle elements of the soap message
    /// and store any unmapped items in the property bag so that
    /// nothing is lost
    /// </summary>
    [Serializable]
    [JsonObject]
    public class SoapBase : JsonBase
    {
        /// <summary>
        /// Default Constructor to set up any undefined elements
        /// </summary>
        public SoapBase() : base()
        {
        }
    }


}