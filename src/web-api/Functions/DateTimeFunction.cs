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
        /// <summary>
        /// Basic implementation of an Azure Function features of interest:
        ///  1. "FunctionName" attribute, this is necessary to register the following implementation as an Azure Function
        ///  2. "HttpTrigger" attribute on the first argument, this is to indicate how the function will be executed at runtime
        ///  3. The array of HTTP methods ("get", "post", "put", "patch", "delete"), one function can be triggered by one or more HTTP method
        ///  4. Static class and static method, if there is no need to use dependency injection within the functions one can use a static implementation
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns>Object containing the current datetime of the server</returns>
        [FunctionName("datetime")]
        public static IActionResult GetDateTime(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", "put", "patch", "delete")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new { CurrentDateTime = DateTime.Now });
        }
    }
}
