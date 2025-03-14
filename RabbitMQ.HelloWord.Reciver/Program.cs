
using RabbitMQ.HelloWord.Reciver;

RabbitMQReciver reciver = new RabbitMQReciver("localhost", "my_test_queue");


await reciver.ReciverMessageAsync();

Console.ReadLine();






