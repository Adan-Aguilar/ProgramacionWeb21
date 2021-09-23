using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstadosMexico.Models;

namespace EstadosMexico.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //OBTENER LOS ESTADOS DE LA BASE DE DATOS
            mexicoContext context = new mexicoContext();
            var estados = context.Estados.OrderBy(x => x.Nombre);

            //PASARLOS A LA VISTA
            return View(estados);

        }
    }
}
