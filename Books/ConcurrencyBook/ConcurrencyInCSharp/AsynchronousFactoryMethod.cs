using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyInCSharp
{
    public class AsynchronousFactoryMethod
    {
       public async Task Proccess()
        {
            var user = await UserProfile.CreateAsync(1);

            
        }

    }

    public class UserProfile
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Theme { get; private set; } 
        public bool NotificationsEnabled { get; private set; }


        private UserProfile(int userId)
        {
            UserId = userId;
        }

        private async Task InitializeAsync()
        {
            Console.WriteLine($"Initializing UserProfile for UserId: {UserId}");

            Console.WriteLine("Fetching user details from API...");
            await Task.Delay(TimeSpan.FromSeconds(1.5)); //شبیه سازی فرایند فراخوانی api
            Username = $"User{UserId}";
            Email = $"user{UserId}@example.com";
            Console.WriteLine($"User details fetched: {Username}, {Email}");

            Console.WriteLine("Fetching user settings from database...");
            await Task.Delay(TimeSpan.FromSeconds(1)); // شبیه سازی فراخوانی DB
            Theme = "Dark";
            NotificationsEnabled = true;
            Console.WriteLine($"User settings fetched: Theme={Theme}, Notifications={NotificationsEnabled}");

            Console.WriteLine($"UserProfile for UserId {UserId} fully initialized.");
        }

        public static async Task<UserProfile> CreateAsync(int userId)
        {

            var userProfile = new UserProfile(userId); // ایجاد نمونه خام
            await userProfile.InitializeAsync(); // اجرای عملیات I/O ناهمزمان
            return userProfile; // بازگرداندن نمونه کامل شده
        }


    }
}
