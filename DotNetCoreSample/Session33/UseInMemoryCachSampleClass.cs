using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace DotNetCoreSample.Session33
{
    public static class UseInMemoryCachSampleClass
    {
        public static void UseMemoryCach(this WebApplication application)
        {
            application.MapGet("/MemoryCach", (HttpRequest request, HttpResponse response, IMemoryCache
                cach) =>
            {
            int number = 0;

            string key = nameof(number);

            number = cach.Get<int>(key);
            number++;

            cach.Set(key, number);

            var hasAbsoluteTime = cach.TryGetValue<DateTime>("absoluteTime", out DateTime dte);

            if (!hasAbsoluteTime)
            {
                    dte = DateTime.Now.AddMinutes(2);
                    cach.Set<DateTime>("absoluteTime", dte);
                    cach.Set(key, number, dte);
            }
                response.WriteAsync($"Number Is {number} Absolute Time is {dte}");
            });
        }
    }

    public static class ConfigClass
    {
        public static void InjectMemoryCach(this WebApplicationBuilder builder)
        {
            //برای اینجکت کردن مموری کش
            builder.Services.AddMemoryCache();
        }
    }
}
