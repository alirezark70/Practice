using HostedService.Posts.Models;

namespace HostedService.Posts.Services
{
    public class PostCache
    {
        private  List<Post> _posts;

        public List<Post> GetPosts()
        {
            return _posts;
        }

        public void SetPosts(List<Post> posts)
        {
            Interlocked.Exchange(ref _posts, posts);
        }

    }
}
