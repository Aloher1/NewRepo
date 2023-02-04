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
            product[] products = new product[3];
            products[0].id = 1;
            products[0].name = "60% BAMBOO CASE";
            products[0].price = 100;
            products[0].description = "ALKSJDKLjmcJKL1234567890-=ASDJXJCKAjsdklJKLSADJKLASCLJCMXZNC<MZXNCLKJKKLSADJKLASJKLDSJKLDSJKLDSJKL";
            list.Add(products[0]);

            products[1].id = 2;
            products[1].name = "60% BRASS ANSI PLATE";
            products[1].price = 200;
            list.Add(products[1]);


            ViewBag.product = list;
            return View();
        }
        public IActionResult product(int id)
        {
            product[] products = new product[3];
            products[0].id = 1;
            products[0].name = "60% BAMBOO CASE";
            products[0].price = 100;
            products[0].description = "ALKSJDKLjmcJKL1234567890-=ASDJXJCKAjsdklJKLSADJKLASCLJCMXZNC<MZXNCLKJKKLSADJKLASJKLDSJKLDSJKLDSJKL";
            list.Add(products[0]);

            products[1].id = 2;
            products[1].name = "60% BRASS ANSI PLATE";
            products[1].price = 200;
            list.Add(products[1]);

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