using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act4DisneyPixar.Models;
using Microsoft.EntityFrameworkCore;

namespace Act4DisneyPixar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("peliculas")]
        public IActionResult Peliculas ()
        {
            pixarContext context = new pixarContext();
            var peliculas = context.Peliculas.OrderBy(x => x.Nombre);
            return View(peliculas);
        }

        [Route("pelicula/{nombre}")]
        public IActionResult InformacionPelicula (string nombre)
        {
         
            
               string nombre2 = nombre== null?"":nombre.Replace("-", " ");
            
            
            pixarContext context = new pixarContext();
            var pelicula = context.Peliculas
                .Include(x=>x.Apariciones)
                .ThenInclude(x=>x.IdPersonajeNavigation)
                .FirstOrDefault(x => x.Nombre== nombre2||x.Nombre == nombre);
            return View(pelicula);

            if (pelicula==null)
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Cortos()
        {
            
            return View();
        }
    }
}
