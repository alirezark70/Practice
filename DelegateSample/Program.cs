// See https://aka.ms/new-console-template for more information

using DelegateSample;

Person p = new Person() { FirstName = "Alireza", LastName = "Rezaee" };
Person N = new Person() { FirstName = "Naser", LastName = "Rezaee" };
PrintPerson person = new();

person.Print(PersonFullName.GetFullNameReverse, p);


/// <summary>
/// ما می توانیم از روی دلیگیت مون اینستنس بسازیم و هر موقع بخواهیم یک هم تایپ بهش پاس بدیم
/// باید در نظر بگیریم که متد را بدون پرانتز باز بسته بنویسم چون پرانتز باز و بسته اون اجرا یا ازکیوت می کنه
/// </summary>
/// 

FullNameToString myDelegate = PersonFullName.GetFullName;

var naserResult=myDelegate(N);
Console.WriteLine(naserResult);

Console.ReadLine();