using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using System.Security.Permissions;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
        
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            HttpContext.Items["user"] = "user";
            ViewBag.product = db.objects.ToList();
            return View();
        }
        public IActionResult product(int id)
        {
            ViewBag.choosenproduct = db.objects.ToList()[id];
            return View();
        }
                
        public IActionResult cartpage(int id)
        {
            ViewBag.cartlist = db.cart.ToList();
            if (id != 0)
            {
                cartproduct p = db.cart.Where(s => s.id == id).FirstOrDefault();
                if (id == p.id)
                {
                    ViewBag.cartlist[id].amount++;
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult cartpage(List<int> checkboxlist)
        {
            ViewBag.cartlist = db.cart.ToList();
            if (checkboxlist.Count > 0)
            {
                foreach(int id in checkboxlist)
                {
                    List<product> orderlist = new List<product>();
                    orderlist.Add(db.objects.Find(id));
                    ViewBag.orderlist = orderlist;
                }
                return View("purchase");
            }
            else
            {
                return View();
            }
        }
        public IActionResult purchase()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}