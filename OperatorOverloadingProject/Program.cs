// See https://aka.ms/new-console-template for more information

using OperatorOverloadingProject;

Money money1 = new(10);
Money money2 = new(20);

//با تعریف عملگرها ما توانستیم دوتا کلاس را به صورت خیلی ساده باهم جمع و تفریق کنیم
Money money3 = money1 + money2;


Console.ReadLine();