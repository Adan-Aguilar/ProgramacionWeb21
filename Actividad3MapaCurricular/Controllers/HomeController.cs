using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actividad3MapaCurricular.Models;

namespace Actividad3MapaCurricular.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            mapa_curricularContext context = new mapa_curricularContext(); //Sirve para hacer la conexión a la base de datos
            var carrera = context.Carreras.OrderBy(x => x.Nombre); //Sirve para traer las carreras de la BD



            return View(carrera);
        }

        public IActionResult Informacion (string id)
        {
            id=id.Replace("-", " ");
            mapa_curricularContext context = new mapa_curricularContext();
            var carrera = context.Carreras.FirstOrDefault(x => x.Nombre == id);

            if (carrera== null)
            {
                return RedirectToAction("Index");
            }
            return View(carrera);
        }
    }
}
