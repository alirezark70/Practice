// See https://aka.ms/new-console-template for more information.

// نمونه ورودی برای آزمایش  

using PostalTest;

LevenshteinDistanceCalculator distanceCalculator= new LevenshteinDistanceCalculator();
string input = "گیلان غرب";
string[] cities = { "تهران", "تهرانپارس", "اصفهان", "کهکیلویه وبویراحمد","کیلانغرب" };

string closestCity = cities.OrderBy(city => LevenshteinDistanceCalculator.Compute(city, input)).First();

Console.WriteLine($"نزدیک‌ترین تطابق برای '{input}'، '{closestCity}' است.");

Console.WriteLine("Hello, World!");



