using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        ApplicationContext db;
        public AdminController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }
        public IActionResult cabinet()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Delete()
        {
            ViewBag.obj = db.objects.ToList();
            return View();
        }
        [HttpPost]
        // public string Index(string login, string password )=>$"Логин: {login} Пароль:{password}";
        public IActionResult Index(string login, string password)
                        
        {
            User u = db.Users.Where(s => s.login == login).FirstOrDefault();
            if (u != null)
                if (u.password == password)
                {
                    if (u.login == "admin")
                    {
                        HttpContext.Items["user"] = "admin";
                        ;
                        return View("AdminPage");
                    }
                    else
                        return View("cabinet");
                }
            return View();

        }
        [HttpGet]
        public IActionResult Add(string name, int price, string category, string description)
        {
            if (HttpContext.Items["user"] == "admin")
            {
                if (name != null && price != null && category != null)
                {
                    product u = new product();
                    u.name = name;
                    u.price = price;
                    u.category = category;
                    u.description = description;
                    db.objects.Add(u);
                    if (db.SaveChanges() > 0)
                        ViewBag.save = true;
                    else
                        ViewBag.save = false;
                }
                return View();
            }
            else
            {
                return Redirect("~/Home/Index");
            }
        }
        [HttpGet]
        public IActionResult Delete(List<int> checkboxlist)
        {
            if (HttpContext.Items["user"] == "admin")
            {
                if (checkboxlist.Count == 0)
                {
                    ViewBag.obj = db.objects.ToList();
                }
                else
                {
                    foreach (int id in checkboxlist)
                    {
                        db.objects.Remove(db.objects.Find(id));
                    }
                    if (db.SaveChanges() > 0)
                        ViewBag.save = true;
                    else
                        ViewBag.save = false;
                    checkboxlist = null;
                    ViewBag.obj = db.objects.ToList();
                }
                return View();
            }
            else
            {
                return Redirect("~/Home/Index");
            }
        }
    }
}
