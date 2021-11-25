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
    /// <summary>
    /// Person API containing many endpoints to interact with the person collection
    /// </summary>
    public class PersonFunction
    {

        private readonly IPersonService personService;

        public PersonFunction(IPersonService personService)
        {
            this.personService = personService;
        }

        /// <summary>
        /// Method to retrieve a defaulted person object.
        /// Used to indicate to the consumer of the API all the properties available on the Person class.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns>Default Person Object</returns>
        [FunctionName("personDefault")]
        public IActionResult GetDefaultPerson(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/default")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(new Person());
        }

        /// <summary>
        /// Method to retrieve all people.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="log"></param>
        /// <returns>IEnumerable<Person>/returns>
        [FunctionName("getPeople")]
        public IActionResult GetPeople(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person")] HttpRequest req,
            ILogger log)
        {
            return new OkObjectResult(personService.GetPeople());
        }

        /// <summary>
        /// Method to retrieve a person by id.
        /// </summary>
        /// <param name="req"></param>
        /// <param name="id"></param>
        /// <param name="log"></param>
        /// <returns>Person</returns>
        [FunctionName("getPersonById")]
        public IActionResult GetPersonById(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "person/{id:guid}")] HttpRequest req,
            Guid id,
            ILogger log)
        {
            if (Guid.Empty == id) return new BadRequestObjectResult("Id passed is default value");
            return new OkObjectResult(personService.GetById(id));
        }

        /// <summary>
        /// Method to create/update a person object. If the id passed is not found in the data set, a new person will be created.
        /// Else, all properties on the found person are updated.
        /// </summary>
        /// <param name="personToUpsert">Updated values of a person</param>
        /// <param name="log"></param>
        /// <returns>Person</returns>
        [FunctionName("upsertPerson")]
        public IActionResult UpsertPerson(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "person")] Person personToUpsert,
            ILogger log)
        {
            return new OkObjectResult(personService.Upsert(personToUpsert));
        }
    }
}
