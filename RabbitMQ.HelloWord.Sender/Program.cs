using RabbitMQ.Client;
using RabbitMQ.HelloWord.Sender.Senders;
using System.Text;


//استفاده از پترن های
//DI
//Strategy Pattern
//Connection Pool

var config = new RabbitMQConfig(hostName: "localhost",5672,"guest", "guest",true, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30), "my_test_queue");
var connectionPool=new RabbitMQConnectionPool(config,10);
ISender send = new DefaultSend(connectionPool);

string massage = "I am Alireza ! Hello";

var sender = new SendClass(send, config, massage);

await sender.Send();



//حالت ساده پیاده سازی

// شیء ConnectionFactory جهت تعیین پارامترهای اتصال به سرور RabbitMQ (لوکال یا ریموت)  
//var connectionFactory = new ConnectionFactory
//{
//    HostName = "localhost",   // نشانی سرور؛ اگر RabbitMQ روی سیستم محلی باشد "localhost"  
//    Port = 5672,             // پورت پیش‌فرض برای اتصال  
//    UserName = "guest",       // نام کاربری پیش‌فرض؛  
//    Password = "guest",       // رمز عبور پیش‌فرض؛  

//    // فعال کردن بازیابی خودکار در صورت قطع ارتباط با سرور  
//    AutomaticRecoveryEnabled = true,

//    // هنگامی که اتصال قطع شود، بعد از 10 ثانیه تلاش می‌کند دوباره وصل شود  
//    NetworkRecoveryInterval = TimeSpan.FromSeconds(10),

//    // بازه زمانی ضربان (Heartbeat) برای بررسی سلامت ارتباط  
//    RequestedHeartbeat = TimeSpan.FromSeconds(30)
//};

//// ایجاد اتصال (Connection) به صورت Async  
//// using var باعث می‌شود در انتهای بلاک، اتصال Dispose شود  
//using var connection = await connectionFactory.CreateConnectionAsync();

//// ایجاد کانال (Channel) به صورت Async  
//// همه عملیات ارسال و دریافت پیام از طریق Channel انجام می‌شود  
//using var channel = await connection.CreateChannelAsync();

//// نام صف یا Queue که پیام‌ها قرار است به آن ارسال شوند  
//string queueName = "my_test_queue";

//// تعریف صف با پارامترهای مورد نظر:  
//// durable = false => صف موقت بوده و پس از ری‌استارت سرور RabbitMQ پاک می‌شود  
//// exclusive = true => صف فقط برای همین اتصال قابل استفاده خواهد بود و با بسته شدن اتصال حذف می‌شود  
//// autoDelete = false => صف با قطع ارتباط مصرف‌کنندگان به صورت خودکار حذف نخواهد شد  
//await channel.QueueDeclareAsync(
//    queue: queueName,
//    durable: false,
//    exclusive: false,
//    autoDelete: false
//);

//// محتوای متنی پیام  
//string message = "Hello from .NET 8!";

//// تبدیل متن به آرایه بایت (RabbitMQ پیام‌ها را به صورت باینری مدیریت می‌کند)  
//var body = Encoding.UTF8.GetBytes(message);

//// ارسال پیام به صورت Async  
//// exchange = "" => استفاده از Exchange پیش‌فرض  
//// routingKey = نام صف => در صورت استفاده از Exchange پیش‌فرض، باید نام صف را قرار دهیم  
//await channel.BasicPublishAsync(
//    exchange: "",
//    routingKey: queueName,
//    body: body
//);


Console.WriteLine("برای خروج کلیدی فشار دهید...");
    Console.ReadKey();
