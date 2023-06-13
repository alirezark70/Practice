// See https://aka.ms/new-console-template for more information



//Func :  دلیگت های هستند که ورودی دارند و خروجی هم دارند و برای راحتی کار از این بهتر است استفاده کنیم تا خود دلیگت چون برای هر عملکردی باید یک دلیگیت درست کنیم
//Action : این دلیگیتی است که ورودی دارد ولی خروجی ندارد 
using FuncAndAction;

Console.WriteLine("Hello, World!");

FuncAndActionClass claaseFunc = new FuncAndActionClass();
//تا شانزده تا می تونه ورودی بگیره و همیشه آخرین پارامتر ما خروجی دلیگیت است
Func<int, int, int, string> funcVariable = claaseFunc.IntToString;
Console.WriteLine(funcVariable(1,2,3));
Console.ReadLine();
