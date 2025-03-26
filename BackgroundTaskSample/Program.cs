using BackgroundTaskSample.Infrastructures;
using BackgroundTaskSample.Services;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddQuartz(e =>
{
});

builder.Services.AddQuartzHostedService(e =>
{
    e.WaitForJobsToComplete = true;
});

//تنظیمات برای تایپ کلاینت هستش 
builder.Services.AddHttpClient<PostService>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});//با این روش لاگ می زنیم


builder.Services.AddTransient<IPostService, PostService>();


builder.Services.AddSingleton<PostCache>(); 

builder.Services.AddHostedService<PostServiceBackgroundService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
