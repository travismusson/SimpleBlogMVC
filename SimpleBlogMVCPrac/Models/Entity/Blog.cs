namespace SimpleBlogMVCPrac.Models.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public required string BlogTitle { get; set; }
        public required string BlogContent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
    }
}
