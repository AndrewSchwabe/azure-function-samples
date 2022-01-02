using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using ServiceBusModel;

namespace ServiceBusConsumer.Functions
{
    public static class GreeterConsumer
    {
        [FunctionName("GreeterConsumer")]
        public static void Run(
            [ServiceBusTrigger("greeter", Connection = "ServiceBusConnection")] Person person, 
            ILogger log)
        {
            log.LogInformation($"Hello, {person.FirstName} {person.LastName}");
        }
    }
}
