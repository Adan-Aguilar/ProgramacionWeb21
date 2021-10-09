using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act4DisneyPixar.Models;

namespace Act4DisneyPixar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Peliculas ()
        {
            pixarContext context = new pixarContext();
            var peliculas = context.Peliculas.OrderBy(x => x.Nombre);
            return View(peliculas);
        }

        public IActionResult Cortos()
        {
            return View();
        }
    }
}
