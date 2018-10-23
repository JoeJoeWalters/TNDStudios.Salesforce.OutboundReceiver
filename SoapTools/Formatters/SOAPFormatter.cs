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
    /// Soap Input formatter for transforming incoming requests to 
    /// a properly formatted Soap Object
    /// </summary> 
    public class SoapFormatter : InputFormatter
    {
        /// <summary>
        /// Tell the system what types of data that this formatter 
        /// can handle processing for
        /// </summary>
        public SoapFormatter()
        {
            // Tell the system what types of data that this formatter can handle processing for
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/xml"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/soap+xml"));
        }

        /// <summary>
        /// Can the type of data that is being passed in to the formatter
        /// be handled?
        /// </summary>
        /// <param name="context">The context of the request holding the request itself</param>
        /// <returns>If the request can be processed by this input formatter</returns>
        public override Boolean CanRead(InputFormatterContext context)
            => IsSoapRequest(context.HttpContext.Request);

        /// <summary>
        /// Check to see if the request indicates that it is a Soap message
        /// </summary>
        /// <param name="request">The request pulled out of the formatter context</param>
        /// <returns>If the message indicates it is a Soap request</returns>
        private Boolean IsSoapRequest(HttpRequest request)
        => GetBody(request)
            .ToLower()
            .Contains("soapenv:envelope");

        /// <summary>
        /// Get the body of the request so it can be processed,
        /// also changes the incoming body stream to a reusable memorystream
        /// as the default stream only allows one hit reading, and as the 
        /// CanRead and Async processing accesses the stream twice it needs 
        /// the ability to seek and read more than once
        /// </summary>
        /// <param name="request">The input request pulled from the context</param>
        /// <returns>The content of the request body</returns>
        private String GetBody(HttpRequest request)
        {
            String content = ""; // The return content

            // Has the body stream been replaced with a seekable memorystream?
            if (!request.Body.CanSeek)
            {
                MemoryStream stream = new MemoryStream(); // Create a new memory stream to replace the standard one
                request.Body.CopyTo(stream); // Copy the origional stream to the memory stream
                request.Body = stream; // Re-assign the stream
            }

            // Reset the stream regardless of it's type
            request.Body.Seek(0, SeekOrigin.Begin); // Reset the position

            // Read the incoming body stream
            var reader = new StreamReader(request.Body);
            content = reader.ReadToEnd(); // Get the stream content
            reader = null; // Can't have a using statement as it kills the stream too

            request.Body.Seek(0, SeekOrigin.Begin); // Reset the position
            return content; // Send the content back
        }

        /// <summary>
        /// Read the body of the input formatter request and produce an action that
        /// can be mapped to the calling object context
        /// </summary>
        /// <param name="context">The incoming request context</param>
        /// <returns>A success of failure result containing the object to be mapped</returns>
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
                // Failed to process this request
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}
