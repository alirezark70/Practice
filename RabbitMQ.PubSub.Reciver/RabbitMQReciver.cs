using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.PubSub.Reciver
{
    public class RabbitMQReciver
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly string _queueName;

        public RabbitMQReciver(string hostName, string queueName)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = hostName,
            };
            _queueName = queueName;
        }

        public async Task ReciverMessageAsync()
        {

            using var connection = await _connectionFactory.CreateConnectionAsync();

            using var channel = await connection.CreateChannelAsync();

            //در این روش از ExchangeType.Fanout استفاده می‌کنیم

            //
            string exchangeName = "myExchangeSample";
            await channel.ExchangeDeclareAsync(
                exchange: exchangeName,
                type: ExchangeType.Fanout,
                durable: false,
                autoDelete: false
            );

            //برای دریافت باید صف را به 
            //exchange
            //متصل کنیم


            await channel.QueueDeclareAsync(
                queue: _queueName,
                durable: false,
                autoDelete: false,
                exclusive: false
            );


            //وقتی صف ایجاد می کنیم یه پروپرتی داره که اسم صف را برای ما میاره

            var queueName = channel.CurrentQueue;
            await channel.QueueBindAsync(
                queue: queueName,
                exchange: exchangeName,
                routingKey: ""
            );
            // تنظیم تعداد پیام‌های همزمان  
            // await channel.BasicQosAsync(0, 1, false);

            // ایجاد Consumer  
            var consumer = new AsyncEventingBasicConsumer(channel);


            consumer.ReceivedAsync += Consumer_ReceivedAsync;

            await channel.BasicConsumeAsync(
                queue: _queueName,
                autoAck: true,
                consumer: consumer
            );

            Console.Write("Press [Enter] to exit");
            Console.ReadLine();

            async Task Consumer_ReceivedAsync(object sender, BasicDeliverEventArgs @event)
            {
                var body = @event.Body.ToArray();

                var stringMessage = Encoding.UTF8.GetString(body);

                Console.WriteLine($"[-] Message recived {stringMessage}");

                //await channel.BasicAckAsync(@event.DeliveryTag, false);



            }
        }




    }
}

