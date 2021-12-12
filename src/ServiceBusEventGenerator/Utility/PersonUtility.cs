using ServiceBusModel;

namespace ServiceBusEventGenerator.Utility
{
    internal class PersonUtility
    {
        /// <summary>
        /// Utility to return a single person with a random first and last name
        /// </summary>
        /// <returns>A mock Person</returns>
        public static Person GetRandomPerson()
        {
            return new Person
            {
                FirstName = NameUtility.GetFirstName(),
                LastName = NameUtility.GetLastName()
            };
        }

        /// <summary>
        /// Utility to return a list of Person objects with a random first and last name
        /// </summary>
        /// <param name="count">The number of Person objects in the list</param>
        /// <returns>A list of mock Persons</returns>
        public static IEnumerable<Person> GetRandomPeople(int count = 10)
        {
            var people = new List<Person>();
            
            for (int i = 0; i < count; i++)
            {
                people.Add(GetRandomPerson());  
            }

            return people;
        }
    }
}
