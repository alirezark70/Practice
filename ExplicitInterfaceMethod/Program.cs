// See https://aka.ms/new-console-template for more information
using ExplicitInterfaceMethod;

//وقتی از متد اینستنس میسازیم ما متد 
//Name
//نمی بینیم
ExplicitInterfaceClasses result = new();

//وقتی به هر کدو از اینترفیس ها کست می کنیم متد قابل مشاهده است.
Animal animal = result;
animal.Name("Dog");

Human human = result;
human.Name("Persian People");

//ما هم از روش بالا می تونیم کست کنیم و هم به روش زیر 
// به دو روش اینکار صورت میگیره
Human human1=new ExplicitInterfaceClasses();


Console.ReadKey();
