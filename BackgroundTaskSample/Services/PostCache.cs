using BackgroundTaskSample.Models;

namespace BackgroundTaskSample.Services
{
    public class PostCache
    {
        private List<Post> _posts;


        public List<Post> Get()
        {
            return _posts;
        }


        public void SetPosts(List<Post> posts)
        {
           Interlocked.Exchange(ref _posts, posts);
        }
    }
}
