
using BackgroundTaskSample.Services;
using Microsoft.OpenApi.Writers;

namespace BackgroundTaskSample.Infrastructures
{
    public class PostServiceBackgroundService : BackgroundService
    {
        private readonly PostCache _postCache;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        // private readonly IPostService _postService;

        //public PostServiceBackgroundService(IPostService postService, PostCache postCache)
        //{
        //    _postService = postService;
        //    _postCache = postCache;
        //}


        public PostServiceBackgroundService( PostCache postCache, IServiceScopeFactory serviceScopeFactory)
        {
            _postCache = postCache;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _postService = scope.ServiceProvider.GetRequiredService<IPostService>();
                var posts = await _postService.GetAllAsync();
                _postCache.SetPosts(posts);
                await Task.Delay(1000, stoppingToken);
            }

        }
    }
}
