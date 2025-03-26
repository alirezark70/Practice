using RabbitMQ.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.PubSub.Sender
{
    public interface ISender : IDisposable
    {
        Task SendMessageAsync(RabbitMQConfig config, byte[] message);
    }

    public class SendClass
    {
        private readonly ISender _sender;
        private readonly RabbitMQConfig _config;
        private readonly string _message;

        public SendClass(ISender sender, RabbitMQConfig config, string message)
        {
            this._sender = sender;
            _config = config;
            _message = message;
        }


        public async Task Send()
        {
            var messageBytes = Encoding.UTF8.GetBytes(_message);

            await _sender.SendMessageAsync(_config, messageBytes);
        }
    }

    public class DefaultSend : ISender
    {
        private readonly RabbitMQConnectionPool _rabbitMQConnectionPool;
        public DefaultSend(RabbitMQConnectionPool rabbitMQConnectionPool)
        {
            _rabbitMQConnectionPool = rabbitMQConnectionPool;
        }

        public async Task SendMessageAsync(RabbitMQConfig config, byte[] message)
        {
            var connectionPool = new RabbitMQConnectionPool(config, 10);

            // ایجاد کانال (Channel) به صورت Async  
            // همه عملیات ارسال و دریافت پیام از طریق Channel انجام می‌شود  
            using var connection = await connectionPool.GetConnectionAsync();

            using var channel = await connection.CreateChannelAsync();

            //در فرایند 
            //pub -sub
            //در اینجا از ExchangeType.Fanout استفاده می‌کنیم
            //یعنی دیگه به صف متصل نمی شیم و به 
            //exchange 
            //منتصل می شویم


            await channel.ExchangeDeclareAsync(
                exchange: config.ExchangeName,
                type: ExchangeType.Fanout,
                durable: config.Durable,
                autoDelete: config.AutoDelete
            );

            // ارسال پیام به صورت Async  
            // exchange = "" => استفاده از Exchange پیش‌فرض  
            // routingKey = نام صف => در صورت استفاده از Exchange پیش‌فرض، باید نام صف را قرار دهیم  
            await channel.BasicPublishAsync(
                exchange: config.ExchangeName,
                routingKey: string.Empty,
                body: message
            );
        }

        public void Dispose()
        {
            _rabbitMQConnectionPool?.Dispose();
        }
    }






    public class RabbitMQConfig
    {


        public RabbitMQConfig(string hostName, int port, string userName, string password, bool automaticRecoveryEnabled,
            TimeSpan networkRecoveryInterval, TimeSpan requestedHeartbeat, string exchangeName, bool durable = false,
            bool exclusive = false, bool autoDelete = false)
        {
            HostName = hostName;
            Port = port;
            UserName = userName;
            Password = password;
            AutomaticRecoveryEnabled = automaticRecoveryEnabled;
            NetworkRecoveryInterval = networkRecoveryInterval;
            RequestedHeartbeat = requestedHeartbeat;
            ExchangeName = exchangeName;
            Durable = durable;
            Exclusive = exclusive;
            AutoDelete = autoDelete;


        }

        public string HostName { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool AutomaticRecoveryEnabled { get; set; }

        public TimeSpan NetworkRecoveryInterval { get; set; }

        public TimeSpan RequestedHeartbeat { get; set; }

        public string ExchangeName { get; set; }

        public bool Durable { get; set; } = false;
        public bool Exclusive { get; set; } = false;
        public bool AutoDelete { get; set; } = false;

    }


    public class RabbitMQConnectionPool : IDisposable
    {
        private readonly ConcurrentBag<IConnection> _connections;
        private readonly ConnectionFactory _connectionFactory;

        private readonly int _maxConnections;
        private bool _disposed;

        public RabbitMQConnectionPool(RabbitMQConfig config, int maxConnections)
        {
            _connections = new ConcurrentBag<IConnection>();

            _connectionFactory = new ConnectionFactory
            {
                HostName = config.HostName,   // نشانی سرور؛ اگر RabbitMQ روی سیستم محلی باشد "localhost"  
                Port = config.Port,             // پورت پیش‌فرض برای اتصال  
                UserName = config.UserName,       // نام کاربری پیش‌فرض؛  
                Password = config.Password,       // رمز عبور پیش‌فرض؛  

                // فعال کردن بازیابی خودکار در صورت قطع ارتباط با سرور  
                AutomaticRecoveryEnabled = config.AutomaticRecoveryEnabled,

                // هنگامی که اتصال قطع شود، بعد از 10 ثانیه تلاش می‌کند دوباره وصل شود  
                NetworkRecoveryInterval = config.NetworkRecoveryInterval,

                // بازه زمانی ضربان (Heartbeat) برای بررسی سلامت ارتباط  
                RequestedHeartbeat = config.RequestedHeartbeat,
            };
            _maxConnections = maxConnections;

            // اجرای غیر همزمان در یک Task  
            InitializeConnectionsAsync().Wait(); // انتظار برای اتمام عملیات  
        }

        private async Task InitializeConnectionsAsync()
        {
            var tasks = new List<Task>(); // ایجاد یک لیست برای نگهداری Task ها  

            // ایجاد اتصالات به صورت غیر همزمان  
            for (int i = 0; i < _maxConnections; i++)
            {
                tasks.Add(CreateConnection()); // اضافه کردن Task به لیست  
            }

            await Task.WhenAll(tasks); // منتظر اتمام تمام Task ها  
        }

        public async Task<IConnection> GetConnectionAsync()
        {
            if (_connections.TryTake(out var connection))
            {
                return connection; // اگر اتصال موجود باشد، آن را برمی‌گرداند  
            }
            else
            {
                return await CreateConnection(); // در صورت عدم وجود، اتصال جدید ایجاد می‌شود  
            }
        }

        private async Task<IConnection> CreateConnection()
        {
            var connection = await _connectionFactory.CreateConnectionAsync();
            _connections.Add(connection);

            return connection;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                foreach (var connection in _connections)
                {
                    connection.Dispose();
                }
                _disposed = true;
            }
        }

    }

}
