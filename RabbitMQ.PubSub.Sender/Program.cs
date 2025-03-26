// See https://aka.ms/new-console-template for more information
using RabbitMQ.PubSub.Sender;

Console.WriteLine("Hello, World!");


var config = new RabbitMQConfig(hostName: "localhost", 5672, "guest", "guest", true, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30), "myExchangeSample");
var connectionPool = new RabbitMQConnectionPool(config, 10);
ISender send = new DefaultSend(connectionPool);

string massage = "I am Alireza ! Hello";


for (int i = 0; i < 100; i++)
{
    var sender = new SendClass(send, config, massage);

    await sender.Send();
}
