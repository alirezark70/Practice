using Microsoft.AspNetCore.Http;

namespace DotNetCoreSample.Session33
{
    public static class UseCookieSampleClass
    {
        public static void SetCookies(this WebApplication application)
        {
            application.MapGet("/Cookie", (HttpRequest request,HttpResponse response) =>
            {
                int numKey = 0;

                string key =nameof(numKey);
                numKey = int.Parse(request.Cookies[key] ?? "0");

                numKey++;

                response.Cookies.Append(key,numKey.ToString(), CookieOptionSampleClass.SetConfig()); 
                response.WriteAsync(numKey.ToString()); 
            });
        }

        
    }
    public class CookieOptionSampleClass
    {
        public static CookieOptions SetConfig()
        {
            return new CookieOptions
            {
                Expires=DateTime.Now.AddMinutes(1),
                IsEssential=true,
                
            };
        }
    }
}
