using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project3.DAL;
using Project3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataDbContext _db;

        public HomeController(DataDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //Post: Register
        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var count = _db.Users.Where(u => u.Email == model.Email).Count();
                if (count == 0)
                {
                    model.Password = model.Password;
                    _db.Add(model);
                    _db.SaveChanges();
                    return View("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        //Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var count = _db.Users.Where(u => u.Email == model.Email && u.Password == model.Password).Count();
                if (count == 1)
                {
                    ViewBag.error = "Successful";
                    return View();
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
