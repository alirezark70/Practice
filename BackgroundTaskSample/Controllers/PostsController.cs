using BackgroundTaskSample.Models;
using BackgroundTaskSample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackgroundTaskSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly PostCache _postCache;
        private readonly IPostService _postService;
        public PostsController(IHttpClientFactory httpClientFactory, IPostService postService, PostCache postCache)
        {
            this._httpClientFactory = httpClientFactory;
            _postService = postService;
            _postCache = postCache;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_postCache.Get());
        }



        //using HttpClientFactory
        [HttpGet("/GetById/{id}")]

        public async Task<IActionResult> Get([FromRoute] int id)
        {

            using HttpClient client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            var result = await client.GetStringAsync($"/posts/{id}");

            var post = JsonConvert.DeserializeObject<Post>(result);

            return Ok(post);
        }


        [HttpGet("GetTypeClient")]
        public async Task<IActionResult> GetTypeClient()
        {

            var posts = await _postService.GetAllAsync();

            return Ok(posts);
        }

    }
}
