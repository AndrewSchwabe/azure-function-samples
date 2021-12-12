using Microsoft.Azure.ServiceBus;
using ServiceBusEventGenerator.Utility;
using System.Text.Json;

// Connection string found in Azure Portal to the Service Bus Resource
var connectionString = "<ServiceBus Connection String>";
// Name of the queue in the resource
var queueName = "greeter";

// Builds a mock list of people objects
var peopleToGreet = PersonUtility.GetRandomPeople();

// Creates a Service Bus message for each person in the list of peopleToGreet
var messages = peopleToGreet
    .Select(p => new Message
    {
        Body = JsonSerializer.SerializeToUtf8Bytes(p)
    })
    .ToList();

// Instance of the queue client, this will be used to establish a connection to Service Bus.
// Once the connection is established, this is the component to send the events to the queue.
var queueClient = new QueueClient(connectionString, queueName);
await queueClient.SendAsync(messages);
