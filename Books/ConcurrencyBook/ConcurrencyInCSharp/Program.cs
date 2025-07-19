// See https://aka.ms/new-console-template for more information

using ConcurrencyInCSharp;

var asyncService = new AsyncService();

var result =await asyncService.GetUsersAsync();

foreach(var item in result)
{
    Console.WriteLine($"Id : {item.Id} Name : {item.Name}");
}

Console.WriteLine("Hello, World!");
