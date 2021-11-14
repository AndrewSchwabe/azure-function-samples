using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using System.Collections.Concurrent;
using WebApi.Services;

namespace WebApi.Functions
{
    public class PersonFunction
    {

        private readonly IPersonService personService;
        
        public PersonFunction(IPersonService personService)
        {
            this.personService = personService;
        }

        [FunctionName("personDefault")]
        public IActionResult GetDefaultPerson(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/default")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new Person());
        }

        [FunctionName("getPeople")]
        public IActionResult GetPeople(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(personService.GetPeople());
        }
    }
}
