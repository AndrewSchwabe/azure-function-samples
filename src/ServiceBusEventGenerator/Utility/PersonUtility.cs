using ServiceBusModel;

namespace ServiceBusEventGenerator.Utility
{
    internal class PersonUtility
    {
        public static Person GetRandomPerson()
        {
            return new Person
            {
                FirstName = NameUtility.GetFirstName(),
                LastName = NameUtility.GetLastName()
            };
        }

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
