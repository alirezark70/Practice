using HostedService.Posts.Models;
using HostedService.Posts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HostedService.Posts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly PostService _postService;
        public PostsController(IHttpClientFactory httpClientFactory, PostService postService)
        {
            this._httpClientFactory = httpClientFactory;
            _postService = postService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            using HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

            var result = await client.GetStringAsync("/posts");

            var posts = JsonConvert.DeserializeObject<List<Post>>(result);

            return Ok(posts);
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
