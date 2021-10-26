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

        //public IActionResult Villancico()
        //{

        //}
    }
    
}
