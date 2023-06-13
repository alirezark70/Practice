// See https://aka.ms/new-console-template for more information

using StructProject;

//قابلیتی که در سی شارپ 10 اضافه شده که مقدار را با کلمه کلیدی
//with 
//میشه فقط به صورت خیلی سریع انقال داد به مدل جدید
StructModelRecord s1= new StructModelRecord() { id = 1 ,name="Alireza",family="Rezaee"};
StructModelRecord s2 = s1 with { name = "Abbas" };
Console.WriteLine("Hello, World!");
