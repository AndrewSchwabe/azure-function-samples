using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using System.Collections.Concurrent;

namespace WebApi.Functions
{
    public class PersonFunction
    {
        private readonly IProducerConsumerCollection<Person> people = new ConcurrentBag<Person>();

        public PersonFunction()
        {
            people.TryAdd(new Person { 
                FirstName = "Andrew",
                LastName = "Schwabe",
                EmailAddress = "schwabea530@gmail.com"
            });
            people.TryAdd(new Person
            {
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "JohnDoe@gmail.com"
            });
            people.TryAdd(new Person
            {
                FirstName = "Jane",
                LastName = "Doe",
                EmailAddress = "JaneDoe@gmail.com"
            });
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
            return new OkObjectResult(people);
        }
    }
}
