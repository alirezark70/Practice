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

    
}
