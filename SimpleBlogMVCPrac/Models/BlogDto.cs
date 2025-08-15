namespace SimpleBlogMVCPrac.Models
{
    public class BlogDto             //similair to the blogdto class, but used for adding a new blog post
    {
        public required string BlogTitle { get; set; }
        public required string BlogContent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
