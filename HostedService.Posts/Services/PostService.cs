using HostedService.Posts.Models;
using Newtonsoft.Json;

namespace HostedService.Posts.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<List<Post>> GetAllAsync()
        {
            var resultString = await _httpClient.GetStringAsync("Posts");

            return JsonConvert.DeserializeObject<List<Post>>(resultString);
        }
    }
}
