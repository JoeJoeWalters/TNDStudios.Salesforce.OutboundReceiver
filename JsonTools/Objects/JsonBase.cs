using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TNDStudios.Tools.Json.Objects
{
    /// <summary>
    /// Base class to handle elements of the soap message
    /// and store any unmapped items in the property bag so that
    /// nothing is lost
    /// </summary>
    [Serializable]
    [JsonObject]
    public class JsonBase
    {
        /// <summary>
        /// Property bag of unmapped data 
        /// </summary>
        [JsonExtensionData]
        public IDictionary<String, JToken> PropertyBag =
            new Dictionary<String, JToken>();

        /// <summary>
        /// Default Constructor to set up any undefined elements
        /// </summary>
        public JsonBase()
        {
            // Create a new property bag, which should be populated, but just incase .. 
            PropertyBag = PropertyBag ?? new Dictionary<String, JToken>();
        }

        /// <summary>
        /// Get the named property with a given type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Object Get(Type type, String propertyName)
            => Convert.ChangeType(Get<Object>(propertyName), type);

        // Get a named property (might be real, might be in the bag)
        public T Get<T>(String propertyName)
        {
            // Result set as the default of it's type to start
            T result = default(T);
            
            // In the property bag?
            if (!PropertyBag.ContainsKey(propertyName))
            {
                // The object type (this is inherited)
                Type callingType = this.GetType(); 

                // Get the property definition for this type
                PropertyInfo property = (callingType.GetProperties())
                    .AsEnumerable()
                    .Where(item => item.Name == propertyName)
                    .FirstOrDefault();

                // Got something?
                if (property != null)
                    result = (T)property.GetValue(this);
            }
            else
                result = PropertyBag[propertyName].Value<T>(); // Return the casted value from the property bag

            // Send the result back
            return result;
        }
    }


}