// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using StructuralPatternSample;
using StructuralPatternSample.Decorator;


var login=new SmsLoginDecorator(new Login());

login.Login();

Console.ReadLine();
