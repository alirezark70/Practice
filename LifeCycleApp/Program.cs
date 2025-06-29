// See https://aka.ms/new-console-template for more information





using LifeCycleApp;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
                .AddTransient<IServiceTransient, ServiceTransient>()
                .AddScoped<IServiceScoped, ServiceScoped>()
                .AddTransient<Consumer>()
                .BuildServiceProvider();


using (var scope1 = serviceProvider.CreateScope())
{
    var consumer1 = scope1.ServiceProvider.GetRequiredService<Consumer>();
    var consumer2 = scope1.ServiceProvider.GetRequiredService<Consumer>();

    Console.WriteLine("=== Scope 1 ===");
    Console.WriteLine($"Consumer1.Transient: {consumer1.Transient.Id}");
    Console.WriteLine($"Consumer2.Transient: {consumer2.Transient.Id}");
    Console.WriteLine($"Consumer1.Scoped:    {consumer1.Scoped.Id}");
    Console.WriteLine($"Consumer2.Scoped:    {consumer2.Scoped.Id}");
}


using (var scope2 = serviceProvider.CreateScope())
{
    var consumer3 = scope2.ServiceProvider.GetRequiredService<Consumer>();
    Console.WriteLine("\n=== Scope 2 ===");
    Console.WriteLine($"Consumer3.Transient: {consumer3.Transient.Id}");
    Console.WriteLine($"Consumer3.Scoped:    {consumer3.Scoped.Id}");
}

Console.ReadKey();





Console.WriteLine("Hello, World!");
