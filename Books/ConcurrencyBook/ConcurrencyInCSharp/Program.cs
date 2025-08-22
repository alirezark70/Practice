// See https://aka.ms/new-console-template for more information

using ConcurrencyInCSharp;

#region Last example
//var asyncService = new AsyncService();

//var result =await asyncService.GetUsersAsync();

//foreach(var item in result)
//{
//    Console.WriteLine($"Id : {item.Id} Name : {item.Name}");
//}


//var cpattern = new AsynchronousFactoryMethod();

//await cpattern.Proccess();



#endregion


#region New Example

// ایجاد محصولات  
var laptop = new Product(1, "لپتاپ گیمینگ", 25000000);
var smartphone = new Product(2, "گوشی هوشمند", 15000000);
var tablet = new Product(3, "تبلت", 10000000);

Console.WriteLine("محصولات ایجاد شدند. تصاویر هنوز بارگذاری نشده‌اند.");

Console.WriteLine($"محصول 1: {laptop.Name} - قیمت: {laptop.Price}");
Console.WriteLine($"محصول 2: {smartphone.Name} - قیمت: {smartphone.Price}");

Console.WriteLine("\nبررسی وضعیت بارگذاری تصاویر:");
Console.WriteLine($"لپتاپ تصاویر بارگذاری شده؟ {laptop.AreImagesLoaded}");
Console.WriteLine($"گوشی تصاویر بارگذاری شده؟ {smartphone.AreImagesLoaded}");

Console.WriteLine("\nبارگذاری تصاویر لپتاپ:");
var laptopImages = laptop.GetImages();
foreach (var image in laptopImages)
{
    Console.WriteLine(image);
}

Console.WriteLine("\nبررسی مجدد وضعیت بارگذاری:");
Console.WriteLine($"لپتاپ تصاویر بارگذاری شده؟ {laptop.AreImagesLoaded}");
Console.WriteLine($"گوشی تصاویر بارگذاری شده؟ {smartphone.AreImagesLoaded}");
#endregion

Console.WriteLine("Hello, World!");
