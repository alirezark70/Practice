// See https://aka.ms/new-console-template for more information


using CSharpInDepth.Part02;

//ModerEventExample moderEvent=new ModerEventExample();

//moderEvent.Execute();


#region Clouser

//ClosureExample2 closure=new ClosureExample2();

//closure.ClosureDemo();
#endregion


#region Lazy and yield
EvenNumberGenerator evenNumber = new EvenNumberGenerator();

Console.WriteLine("فراخوانی GetEvenNumbersEager:");
foreach (int num in EvenNumberGenerator.GetEvenNumbersEager(1, 10))
{
    Console.WriteLine($"Consumed (Eager): {num}");
    // فرض کنید اینجا بعد از یافتن 4 دیگر به بقیه نیاز نداریم
    if (num == 4)
    {
        Console.WriteLine("کافیه! ادامه نمیدیم.");
        break;
    }
}
Console.WriteLine("\n----------------------------------\n");

// مقایسه با روش Lazy (ایتریتور)
Console.WriteLine("فراخوانی GetEvenNumbersLazy:");
foreach (int num in EvenNumberGenerator.GetEvenNumbersLazy(1, 10))
{
    Console.WriteLine($"Consumed (Lazy): {num}");
    // فرض کنید اینجا بعد از یافتن 4 دیگر به بقیه نیاز نداریم
    if (num == 4)
    {
        Console.WriteLine("کافیه! ادامه نمیدیم.");
        break;
    }
}
#endregion





Console.WriteLine("Hello, World!");
