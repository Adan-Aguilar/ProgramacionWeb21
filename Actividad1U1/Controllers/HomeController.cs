using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad1U1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Programación Web, Semestre 9, periodo Agosto-Diciembre 2021, Adán Daniel Aguilar Romero";
        }

        public IActionResult Miperfil()
        {
            return View();
        }
    }
}
