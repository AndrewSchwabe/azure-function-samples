using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Functions
{
    public class PersonFunction
    {
        [FunctionName("personDefault")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/default")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new Person());
        }
    }
}
