using BackgroundTaskSample.Models;
using Newtonsoft.Json;

namespace BackgroundTaskSample.Services
{

    public interface IPostService
    {
        Task<List<Post>> GetAllAsync();
    }


    public class PostService: IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }


        public async Task<List<Post>> GetAllAsync()
        {

            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            var resultString = await _httpClient.GetStringAsync("Posts");

            return JsonConvert.DeserializeObject<List<Post>>(resultString);
        }
    }
}


    
