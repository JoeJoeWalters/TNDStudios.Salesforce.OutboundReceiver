using Newtonsoft.Json;
using System;

namespace TNDStudios.Tools.Soap.Objects
{
    /// <summary>
    /// Object to hold the Soap message envelope which encompases the passed
    /// in data
    /// </summary>
    /// <typeparam name="T">The object that the envelope will transform in to</typeparam>
    [Serializable]
    [JsonObject]
    public class SoapEnvelope<T> : SoapBase where T : new()
    {
        /// <summary>
        /// The body of the message as a type, so the object that
        /// the message will transform / map in to
        /// </summary>
        [JsonProperty(PropertyName = "soapenv:body")]
        public T Body { get; set; }

        /// <summary>
        /// The namespace definition of the envelope, that can
        /// be a couple of different namespaces that can be used for Soap
        /// messages
        /// </summary>
        [JsonProperty(PropertyName = "@xmlns:soapenv")]
        public String Namespace { get; set; }

        /// <summary>
        /// The Xsd location
        /// </summary>
        [JsonProperty(PropertyName = "@xmlns:xsd")]
        public String Xsd { get; set; }

        /// <summary>
        /// The Xsi location
        /// </summary>
        [JsonProperty(PropertyName = "@xmlns:xsi")]
        public String Xsi { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SoapEnvelope() : base()
        {
        }
    }
}
