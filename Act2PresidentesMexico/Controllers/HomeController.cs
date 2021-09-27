using Act2PresidentesMexico.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Act2PresidentesMexico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            presidentesContext context = new presidentesContext();
            IEnumerable<Presidente> presidentes = context.Presidentes.OrderByDescending(x => x.InicioGobierno);
            return View(presidentes);
        }

        public IActionResult Biografia ()
        {
            return View();
        }
    }
}
