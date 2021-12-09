namespace ServiceBusEventGenerator.Utility
{

    internal static class NameUtility
    {
        private static List<string> FirstNames => new List<string>
        {
            "James",
            "Robert",
            "John",
            "Michael",
            "William",
            "David",
            "Richard",
            "Joseph",
            "Thomas",
            "Charles",
            "Christopher",
            "DanieL",
            "Matthew",
            "Anthony",
            "Mark",
            "Donald",
            "Steven",
            "Paul",
            "Andrew",
            "Joshua",
            "Kenneth",
            "Kevin	",
            "Brian	",
            "George	",
            "Edward	",
            "Ronald	",
            "Timothy",
            "Jason	",
            "Jeffrey",
            "Ryan	",
            "Jacob	",
            "Gary	",
            "Nicholas",
            "Eric	",
            "Jonathan",
            "Stephen",
            "Larry	",
            "Justin	",
            "Scott	",
            "Brandon",
            "Benjamin",
            "Samuel	",
            "Gregory",
            "Frank",
            "Alexander",
            "Raymond",
            "Patrick",
            "Jack	",
            "Dennis	",
            "Jerry	"
        };

        private static List<string> LastNames => new List<string>
        {
            "Smith",
            "Johnson",
            "Williams",
            "Brown",
            "Jones",
            "Garcia",
            "Miller",
            "Davis",
            "Rodriguez",
            "Martinez",
            "Hernandez",
            "Lopez",
            "Gonzalez",
            "Wilson",
            "Anderson",
            "Thomas",
            "Taylor",
            "Moore",
            "Jackson",
            "Martin",
            "Lee",
            "Perez",
            "Thompson",
            "White",
            "Harris",
            "Sanchez",
            "Clark",
            "Ramirez",
            "Lewis",
            "Robinson",
            "Walker",
            "Young",
            "Allen",
            "King",
            "Wright",
            "Scott",
            "Torres",
            "Nguyen",
            "Hill",
            "Flores",
            "Green",
            "Adams",
            "Nelson",
            "Baker",
            "Hall",
            "Rivera",
            "Campbell",
            "Mitchell",
            "Carter",
            "Roberts"
        };

        private static Random Random => new Random();

        public static string GetFirstName()
        {
            return FirstNames[Random.Next(0, FirstNames.Count - 1)];
        }

        public static string GetLastName()
        {
            return LastNames[Random.Next(0, LastNames.Count - 1)];
        }
    }
}
