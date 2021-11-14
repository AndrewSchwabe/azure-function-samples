using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using WebApi.Services;
using System;

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

        [FunctionName("getPersonById")]
        public IActionResult GetPersonById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/{id:guid}")] HttpRequest req,
            Guid id,
            ILogger log)
        {
            if (Guid.Empty == id) return new BadRequestObjectResult("Id passed is default value");
            return new OkObjectResult(personService.GetById(id));
        }

        [FunctionName("upsertPerson")]
        public IActionResult UpsertPerson(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "person")] Person personToUpsert,
            ILogger log)
        {
            return new OkObjectResult(personService.Upsert(personToUpsert));
        }
    }
}
