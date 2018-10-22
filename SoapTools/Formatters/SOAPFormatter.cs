using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace TNDStudios.Tools.Soap
{
    /// <summary>
    /// Passthrough for data with no interferance
    /// </summary> 
    public class SoapFormatter : InputFormatter
    {
        // Tell the system it can handle XML
        public SoapFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/soap+xml"));
        }

        // Can always read
        public override Boolean CanRead(InputFormatterContext context)
            => IsSalesforceMessage(context.HttpContext.Request);

        // Check the request to see if it is a Salesforce message
        private Boolean IsSalesforceMessage(HttpRequest request)
        => GetBody(request)
            .Contains("http://soap.sforce.com/2005/09/outbound");

        // Get the body of the request
        private String GetBody(HttpRequest request)
        {
            String content = ""; // The return content

            // Has the body stream been replaced with a seekable memorystream?
            if (!request.Body.CanSeek)
            {
                MemoryStream stream = new MemoryStream();
                request.Body.CopyTo(stream);
                request.Body = stream;
            }

            // Reset the stream
            request.Body.Seek(0, SeekOrigin.Begin); // Reset the position

            // Read the incoming body stream
            var reader = new StreamReader(request.Body);
            content = reader.ReadToEnd(); // Get the stream content
            reader = null; // Can't have a using statement as it kills the stream too

            request.Body.Seek(0, SeekOrigin.Begin); // Reset the position
            return content; // Send the content back
        }

        // Read the body and always be successful
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            try
            {
                // Get the outgoing bound type to map to
                Type modelType = context.ModelType;

                // Load an Xml Document with the incoming stream
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(GetBody(context.HttpContext.Request));

                // Convert the XmlDocument to a Json Text representation
                string jsonText = JsonConvert.SerializeXmlNode(doc, Formatting.Indented);

                // Create a new outbound message
                Object outboundMessage = Activator.CreateInstance(modelType);

                // Convert the Json representation to the object
                outboundMessage = JsonConvert.DeserializeObject(jsonText,
                    modelType,
                    new JsonSerializerSettings()
                    {

                    });

                // Return the result
                return await InputFormatterResult.SuccessAsync(outboundMessage);
            }
            catch (Exception ex)
            {
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}
