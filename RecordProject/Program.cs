// See https://aka.ms/new-console-template for more information

using RecordProject;


PersonClass pClass1 = new() { Id = 1, FirstName = "Alireza", LastName = "Rezaee" };
PersonClass pClass2 = new() { Id = 1, FirstName = "Alireza", LastName = "Rezaee" };

PersonRecord pRecord1= new() { Id = 1, FirstName = "Alireza", LastName = "Rezaee" };
PersonRecord pRecord2 = new() { Id = 1, FirstName = "Alireza", LastName = "Rezaee" };

//متد 
//toString
//بازنویسی شده و اطلاعات بهتری را به ما میده در رکورد
Console.WriteLine(pClass1);
Console.WriteLine(pRecord1);


//رفرنس ها یکی هستند
Console.WriteLine(object.ReferenceEquals(pRecord1, pRecord2));
Console.WriteLine(object.ReferenceEquals(pClass1, pClass2));

//در کلاس رفرنس ها قیاس شده ولی در رکورد پروپرتی ها بررسی می شوند و اگر برابر باشند باهم براربرند
//ولی در کلاس هیچ وقت رفرنس ها باهم برابر نیستند
Console.WriteLine(pClass1 == pClass2);
Console.WriteLine(pRecord1 == pRecord2);


/// <summary>
/// With For Copy Data To New Insial 
/// برای راحتی کار در رکورد ما کلمه کلیدی 
/// with  
/// داریم که یک فیلد یا چندتا رو تغییر میده به شکل زیر
/// </summary>
PersonPrimaryRecord pPRecord=new PersonPrimaryRecord(1,"Alireza","Rezaee");
PersonPrimaryRecord pPRecord2 = pPRecord with { Id = 2 };
Console.ReadLine();
