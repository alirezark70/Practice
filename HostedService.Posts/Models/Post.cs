namespace HostedService.Posts.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string title { get; set; }
        public string Body { get; set; }
    }
}
