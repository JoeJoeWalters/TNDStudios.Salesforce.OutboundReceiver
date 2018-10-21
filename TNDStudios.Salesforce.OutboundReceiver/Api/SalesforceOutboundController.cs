using System;
using Microsoft.AspNetCore.Mvc;
using TNDStudios.Salesforce.OutboundReceiver.Objects;
using Formatting = Newtonsoft.Json.Formatting;

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
        
        [Consumes(@"application/xml")]
        [HttpPost]
        public Boolean Post([FromBody]SOAPMessage<SalesforceNotificationsBody> message)
        {
            return true;
        }
    }
}
