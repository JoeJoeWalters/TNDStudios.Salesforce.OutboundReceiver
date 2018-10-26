using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TNDStudios.Salesforce.OutboundReceiver.Api
{
    /// <summary>
    /// Base class
    /// </summary>
    [ApiController]
    public class VersionedControllerBase : Controller
    {
        /// <summary>
        /// Get the version number of the Api from the route information
        /// </summary>
        protected ApiVersion RequestedApiVersion => HttpContext.GetRequestedApiVersion();
    }
}
