﻿using Microsoft.AspNetCore.Mvc;

namespace TrueOnion.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return RedirectToAction("Login", "Account");
            return RedirectToAction("Index", "Home", new { area = "Admin" });
        }
    }
}
