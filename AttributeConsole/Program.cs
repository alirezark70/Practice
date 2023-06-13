
using AttributeConsole;

Person p = new Person { FirstName="Alireza",LastName="Rezaee",Age=31};

PersonPrint PersonPrint = new(p);
PersonPrint.Print();

Console.ReadLine();