// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using StructuralPatternSample;


var login=new SmsLoginDecorator(new Login());

login.Login();

Console.ReadLine();
