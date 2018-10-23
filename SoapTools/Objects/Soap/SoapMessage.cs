using Newtonsoft.Json;
using System;

namespace TNDStudios.Tools.Soap.Objects
{
    /// <summary>
    /// THe object that holds the root of the message
    /// </summary>
    /// <typeparam name="T">
    /// The type of object that this soap message will hold and 
    /// deserialise to
    /// </typeparam>
    [Serializable]
    [JsonObject]
    public class SoapMessage<T> : SoapBase where T : new()
    {
        /// <summary>
        /// Marker for the Soap envolope which will hold the data
        /// </summary>
        [JsonProperty(PropertyName = "soapenv:Envelope")]
        public SoapEnvelope<T> Envelope { get; set; }

        /// <summary>
        /// The Xml header record which holds the Xml version and the encoding
        /// </summary>
        [JsonProperty(PropertyName = "?xml")]
        public SoapXmlHeader XMLHeader { get; set; }

        /// <summary>
        /// Default constructor to set up any undefined elements by default
        /// </summary>
        public SoapMessage() : base()
        {
            Envelope = new SoapEnvelope<T>(); // Main body envelope
            XMLHeader = new SoapXmlHeader(); // The Xml header holding the encoding etc.
        }
    }
}
