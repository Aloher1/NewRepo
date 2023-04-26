﻿using Microsoft.AspNetCore.Mvc;
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