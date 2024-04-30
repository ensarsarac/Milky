﻿using Microsoft.AspNetCore.Mvc;

namespace Milky.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
