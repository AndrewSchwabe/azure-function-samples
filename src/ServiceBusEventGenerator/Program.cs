using Microsoft.Azure.ServiceBus;
using ServiceBusModel;
using System.Text.Json;

var connectionString = "<ServiceBus connection string>";
var queueName = "greeter";

var queueClient = new QueueClient(connectionString, queueName);

var person = new Person {

    FirstName = "Andrew",
    LastName =  "Test"
};

var message = new Message {
    Body =  JsonSerializer.SerializeToUtf8Bytes(person)
};

await queueClient.SendAsync(message);
