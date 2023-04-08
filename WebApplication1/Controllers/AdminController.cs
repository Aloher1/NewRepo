using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       // public string Index(string login, string password )=>$"Логин: {login} Пароль:{password}";

        public IActionResult Index(string login, string password)
        {
            if(login == "admin" && password == "admin")
            {
                return View("AdminPage");
            }
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
