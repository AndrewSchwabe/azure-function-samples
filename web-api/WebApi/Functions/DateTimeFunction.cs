using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApi.Functions
{
    public static class DateTimeFunction
    {
        [FunctionName("datetime")]
        public static IActionResult GetDateTime(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", "put", "patch", "delete", Route = null)] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new { CurrentDateTime = DateTime.Now });
        }
    }
}
