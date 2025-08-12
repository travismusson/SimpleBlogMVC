using Microsoft.EntityFrameworkCore;
using SimpleBlogMVCPrac.Models;
namespace SimpleBlogMVCPrac.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<BlogDto> BlogPost { get; set; }

    }
}
