﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KMSUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}