using Microsoft.Azure.ServiceBus;
using ServiceBusEventGenerator.Utility;
using System.Text.Json;

var connectionString = "<ServiceBus Connection String>";
var queueName = "greeter";

var queueClient = new QueueClient(connectionString, queueName);

var peopleToGreet = PersonUtility.GetRandomPeople();

var messages = peopleToGreet
    .Select(p => new Message
    {
        Body = JsonSerializer.SerializeToUtf8Bytes(p)
    })
    .ToList();

await queueClient.SendAsync(messages);
