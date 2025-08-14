using Microsoft.EntityFrameworkCore;
using SimpleBlogMVCPrac.Models.Entity;
namespace SimpleBlogMVCPrac.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<Blog> BlogPost { get; set; }

    }
}
