using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVCPrac.Data;
using SimpleBlogMVCPrac.Models.Entity;
using SimpleBlogMVCPrac.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlogMVCPrac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDbContext dbContext;

        public HomeController(ILogger<HomeController> logger, BlogDbContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allBlogs = await dbContext.BlogPost.ToListAsync();
            return View(allBlogs);
        }
        /*
        public IActionResult Blog()     //httpget
        {
            return View();
        }
        */
        public IActionResult CreateBlog()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()      //stopping here tonight, gonna push to git     //https://www.youtube.com/watch?v=6YIRKBsRWVI
        {
            //gonna use this to get all blogs from the database
            var allBlogs = await dbContext.BlogPost.ToListAsync();      //changed to asyncronous to allow for better performance and scalability
            return View(allBlogs);
            
            
            
            
            //Refactor
            /*Console.WriteLine("Success here is the list of current blogs");     //temp
            foreach(var blog in allBlogs)       //loop through the blogs and print them to the console      //temp
            {
                Console.WriteLine($"Blog ID: {blog.Id}, Title: {blog.BlogTitle}, Content: {blog.BlogContent}, Created At: {blog.CreatedAt}, Updated At: {blog.UpdatedAt}");
            }
            return Ok(allBlogs);        //returns 200 success status code with the list of blogs
            */
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(AddBlogDto addBlogDto)      //made this asyncronous
        {
            
            if (ModelState.IsValid)     //checks models state to see if its valid
            {
                // Map the AddBlogDto to a Blog entity
                var blogEntity = new Blog       //create a blog entity from the Blog class
                {
                    BlogTitle = addBlogDto.BlogTitle,       //map the properties from the AddBlogDto to the Blog entity
                    BlogContent = addBlogDto.BlogContent,
                    CreatedAt = addBlogDto.CreatedAt,
                    UpdatedAt = addBlogDto.UpdatedAt
                };
                // Add the new blog post to the database
                await dbContext.BlogPost.AddAsync(blogEntity);  //add the blog entity to the database context
                
                await dbContext.SaveChangesAsync();        //required to showcase changes to the database, also changed to async
                //Console.WriteLine("Success: Created Entity");     //temp
                //return Ok(blogEntity);         //returns the 200 success status and the blog entity that was created
                return RedirectToAction("BlogDetail", "Home", new { id =  blogEntity.Id});
            }
            return View(); // If model state is invalid, return the same view with the model
        }

        public async Task<IActionResult> BlogDetail(int id)     //gonna use the blog id to view more detail about the blog post
        {
            var blog = await dbContext.BlogPost.FindAsync(id);      //find the blog post by id
            if (blog == null)      //if the blog post is not found, return not found
            {
                return NotFound();
            }
            return View(blog);      //return the blog post to the view
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
