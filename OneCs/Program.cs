// See https://aka.ms/new-console-template for more information


using OneCs;

//string? firstName = null;
//Person p1 = new Person() { LastName="Naser"};

//p1.FirstName = "Alireza";
//Console.WriteLine(firstName?.ToUpper());

Person p1 = new();
var  result=p1.PrintFullName("Alireza", "Rezaee", "CSharp", "Developer", "Progammer", "SqlServer","Mvc","Core","Linq");

var _ = new
{
    FirstName = "Alireza",
    LastName = "Rezaee"
};

Console.ReadLine();
