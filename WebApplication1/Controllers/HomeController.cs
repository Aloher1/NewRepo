using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using System.Security.Permissions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        List<product> list = new List<product>();
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.product = list;
            return View();
        }
        public IActionResult product(int id)
        {

            ViewBag.choosenproduct = list[id];
            return View();
        }

        public IActionResult cartpage(int id)
        {
            ViewBag.cartproduct = list[id];
            return View();
        }
     
        /*
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}