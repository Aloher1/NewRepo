using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
       // public string Index(string login, string password )=>$"Логин: {login} Пароль:{password}";

        public IActionResult Index(string login, string password)
        {
            User u = db.Users.Where(s => s.login == login).FirstOrDefault();
            if (u != null)
                if (u.password == password)
                {
                    if (u.login == "admin")
                        return View("AdminPage");
                    else
                        return View("cabinet");
                }
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
        [HttpGet]
        public IActionResult Add(string name, int price, string category, string file)
        {
            if (name != null && price != null && category != null)
            {
                product u = new product();
                u.name = name;
                u.price = price;
                u.category = category;
                db.objects.Add(u);
                if(db.SaveChanges() > 0)
                    ViewBag.save = true;
                else
                    ViewBag.save = false;
            }
            return View();
        }
    }
}
