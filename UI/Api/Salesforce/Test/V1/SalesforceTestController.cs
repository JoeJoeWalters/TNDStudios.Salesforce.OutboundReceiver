using System;
using Microsoft.AspNetCore.Mvc;
using TNDStudios.Data.Repository;
using TNDStudios.Salesforce.OutboundReceiver.Objects;
using TNDStudios.Tools.Soap.Objects;

namespace TNDStudios.Salesforce.OutboundReceiver.Api.Salesforce.Test.V1
{
    /// <summary>
    /// Controller to manage Salesforce outbound notifications
    /// </summary>
    [ApiVersion("0.9", Deprecated = true)]
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{api-version:apiVersion}/salesforce/test")]
    public class SalesforceTestController : Controller
    {
        /// <summary>
        /// Data repository
        /// </summary>
        private static IDataRepository<TestSalesforceObject> repository;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesforceTestController()
        {
            // Create a new repository if not already set up
            repository = repository ??
                new SqlDataRepository<TestSalesforceObject>()
                {
                    ConnectionString = "Server=LAPTOP-0VTBLBTI;Database=TransactionRepository;User Id=TransactionUser;Password=password;",
                    InsertMapping = @"insert into dbo.Workers(Email, TR_ObjectPkId, TR_ApiVersion, TR_SourceSystem, TR_SourceType) values(@Email, @Id, 0.9, 'Salesforce', 'Lead')"
                };
        }
        
        /// <summary>
        /// Provide an endpoint to recieve a soap notification message
        /// in a structure that recognises notifications from Salesforce
        /// </summary>
        /// <param name="message">The translated Soap request as an object</param>
        /// <returns>A success or failure response</returns>
        [Consumes(@"application/soap+xml", otherContentTypes: @"text/xml")]
        [HttpPost]
        public Boolean Post([FromBody]SoapMessage<SalesforceNotificationsBody<TestSalesforceObject>> message)
        {
            TestSalesforceObject sfObject = message.Envelope.Body.Notifications.Items[0].SalesforceObject;
            return repository.Save(sfObject);
        }
    }
}
