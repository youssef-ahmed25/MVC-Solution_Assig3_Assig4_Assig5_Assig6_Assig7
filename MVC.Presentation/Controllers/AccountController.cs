﻿using Microsoft.AspNetCore.Mvc;

namespace MVC.Presentation.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
