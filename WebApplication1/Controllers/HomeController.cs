﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using System.Security.Permissions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;
         List<cartproduct> orderlist = new List<cartproduct>();

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
            List<cartproduct> list = new List<cartproduct>();
            list = db.cart.ToList();
            ViewBag.cartlist = list;
            
            if (checkboxlist.Count > 0)
            {
                for(int i = 1;i <= list.Count; i++)
                {
                    bool del = true;
                    foreach(int id in checkboxlist)
                    {
                        if(i == id)
                        {
                            del = false;
                        }
                    }
                    if (del == true)
                    {
                        db.cart.Remove(db.cart.Find(i));
                        db.SaveChanges();//db.Entry(db.cart.Find(i)).State = EntityState.Modified;
                    }

                }
                    return Redirect("purchase");
            }
            else
            {
                return View();
            }
        }
        
        [HttpGet]
        public IActionResult purchase(string name, string surname, int price, string address, string telephone, DateTime date)
        {
            ViewBag.cartlist = db.cart.ToList();
            if (name != null && surname != null && address != null && telephone != null)
            {
                for (int i = 0; i < db.cart.ToList().Count; i++)
                {
                    order u = new order();
                    u.productid = db.cart.ToList()[i].id;
                    u.productname = db.cart.ToList()[i].name;
                    u.name = name;
                    u.surname = surname;
                    u.price = db.cart.ToList()[i].price;//
                    u.address = address;
                    u.telephone = telephone;
                    //u.date = date;
                    db.Orders.Add(u);
                    db.SaveChanges();
                    
                }
                return Redirect("Index");
            }

            else
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