using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FutureValue.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Mary";
            ViewBag.Fv = 99999.99;
            ViewBag.Correo = "clayaldas@gmail.com";
            return View();
        }
    }
}