using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;

namespace TNDStudios.Tools.Soap.Objects
{
    /// <summary>
    /// Base class to handle elements of the soap message
    /// and store any unmapped items in the property bag so that
    /// nothing is lost
    /// </summary>
    [Serializable]
    [JsonObject]
    public class SoapBase
    {
        /// <summary>
        /// Property bag of unmapped data 
        /// </summary>
        [JsonExtensionData]
        public IDictionary<String, Object> PropertyBag =
            new Dictionary<String, Object>();

        /// <summary>
        /// Default Constructor to set up any undefined elements
        /// </summary>
        public SoapBase()
        {
            // Create a new property bag, which should be populated, but just incase .. 
            PropertyBag = PropertyBag ?? new Dictionary<String, Object>();
        }
    }


}