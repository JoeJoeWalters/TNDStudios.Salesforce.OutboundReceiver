using System;
using Microsoft.AspNetCore.Mvc;
using TNDStudios.Salesforce.OutboundReceiver.Objects;
using TNDStudios.Tools.Soap.Objects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TNDStudios.Salesforce.OutboundReceiver.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesforceOutboundController : Controller
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SalesforceOutboundController()
        {
        }
        
        [Consumes(@"application/soap+xml", otherContentTypes: @"text/xml")]
        [HttpPost]
        public Boolean Post([FromBody]SoapMessage<SalesforceNotificationsBody<TestSalesforceObject>> message)
        {
            return true;
        }
    }
}
