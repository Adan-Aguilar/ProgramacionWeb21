using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad2U1.Models;

namespace Actividad2U1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "PROMEDIO CALIFICACIONES";
        }

    

        public IActionResult PaginaPromedio(int Calificacion1, int Calificacion2, int Calificacion3)
        {
            PaginaPromedioViewModel vm = new PaginaPromedioViewModel();
            vm.Calificacion1 = Calificacion1;
            vm.Calificacion2 = Calificacion2;
            vm.Calificacion3 = Calificacion3;
            return View (vm);
        }

        public IActionResult resultado (int Calificacion1, int califiacion2, int calificacion3)
        {
            return Ok((Calificacion1 + califiacion2 + calificacion3) / 3);
        }

    
    }
}
