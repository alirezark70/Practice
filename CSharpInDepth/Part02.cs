using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpInDepth
{
    internal class Part02
    {
    }


    public class ModerEventExample
    {
        //تعریف یک ایونت هندلر با 
        //nullable reference type
        public event EventHandler<string>? _messageRecived;


        private static void HandlerMessage(object? sender , string? message)
        {
            Console.WriteLine($"Message recived from {sender?.GetType().Name} : {message}");
        }


        private static void LogMessage(object? sender, string? message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now} : {message} ");
        }

        public void Execute()
        {
            _messageRecived += HandlerMessage;
            _messageRecived += LogMessage;

            _messageRecived.Invoke(this, "Test Hanlder");


        }

    }

    #region Closure

    public class ClosureExample
    {
        private readonly object _lockObject=new object();
        public Action<string> CreateCustomLogger(string prefix)
        {
            int callCount = 0; // متغیر محلی که "capture" می‌شود

            // Lambda expression که متغیرهای محلی را capture می‌کند
            return message =>
            {
                lock(_lockObject)
                {
                    callCount++; // دسترسی به متغیر محلی حتی بعد از خروج از CreateCustomLogger

                }
                Console.WriteLine($"[{prefix}] Call #{callCount}: {message}");
            };
        }

        public void ClosureDemo()
        {
            // ایجاد دو logger مختلف با prefix های متفاوت
            var errorLogger = CreateCustomLogger("ERROR");
            var infoLogger = CreateCustomLogger("INFO");

            // استفاده از closure ها - هر کدام counter جداگانه دارند
            errorLogger("Database connection failed");
            // Output: [ERROR] Call #1: Database connection failed

            errorLogger("Invalid user credentials");
            // Output: [ERROR] Call #2: Invalid user credentials

            infoLogger("User logged in successfully");
            // Output: [INFO] Call #1: User logged in successfully

            errorLogger("Server timeout");
            // Output: [ERROR] Call #3: Server timeout
        }




    }

    public class ClosureExample2
    {
        private  Func<int,int> CreateMultiplier(int  multiplier)
        {
            return x=> x*multiplier;
        }


        public void ClosureDemo()
        {
            var multiplier5=CreateMultiplier(5);


            var result = multiplier5(10);
        }
    }

    #endregion
}
