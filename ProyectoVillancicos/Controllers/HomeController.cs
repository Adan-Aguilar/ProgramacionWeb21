using Microsoft.AspNetCore.Mvc;
using ProyectoVillancicos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVillancicos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            villancicosContext context = new villancicosContext();
            var villancico = context.Villancicos.OrderBy(x => x.Nombre);
            return View(villancico);
        }

        public IActionResult Villancico(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            villancicosContext context = new villancicosContext();
            var villancico = context.Villancicos.FirstOrDefault(x => x.Id == id);

            if (villancico == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(villancico);
            }

        }
    }
    
}
