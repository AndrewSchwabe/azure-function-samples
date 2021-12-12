using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ServiceBusModel;

namespace ServiceBusConsumer
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
