using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Services
{
    public class InMemoryPersonService : IPersonService
    {
        private readonly IProducerConsumerCollection<Person> people = new ConcurrentBag<Person>();

        public InMemoryPersonService()
        {
            people.TryAdd(new Person
            {
                Id = new Guid("ce059f09-f2a0-4a59-8fa8-bd7c2f677496"),
                FirstName = "Andrew",
                LastName = "Schwabe",
                EmailAddress = "schwabea530@gmail.com"
            }); ;
            people.TryAdd(new Person
            {
                Id = new Guid("6dfd3209-543c-4e57-944d-cd1a7d553a45"),
                FirstName = "John",
                LastName = "Doe",
                EmailAddress = "JohnDoe@gmail.com"
            });
            people.TryAdd(new Person
            {
                Id = new Guid("f741eee0-6651-411a-8659-1a523f3bb67a"),
                FirstName = "Jane",
                LastName = "Doe",
                EmailAddress = "JaneDoe@gmail.com"
            });
        }

        public IEnumerable<Person> GetPeople()
        {
            return people;
        }
    }
}
