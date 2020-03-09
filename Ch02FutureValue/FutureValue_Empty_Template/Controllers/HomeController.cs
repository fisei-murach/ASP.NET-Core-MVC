using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValue_Empty_Template.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Luis";
            ViewBag.Apellido = "Torres";

            return View();
        }

        public string Mensaje()
        {
            return "Hola mundo";
        }

        public IActionResult MensajeConView()
        {
            return View("Mensaje desde un View");
        }
    }
}
