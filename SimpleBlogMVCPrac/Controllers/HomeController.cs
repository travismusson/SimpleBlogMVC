using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVCPrac.Models;

namespace SimpleBlogMVCPrac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult CreateBlog()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllBlogs()      //stopping here tonight, gonna push to git     //https://www.youtube.com/watch?v=6YIRKBsRWVI
        {
            //gonna use this to get all blogs from the database
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
