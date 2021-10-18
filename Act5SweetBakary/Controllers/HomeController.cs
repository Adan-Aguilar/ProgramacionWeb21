using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act5SweetBakary.Models;
using Microsoft.EntityFrameworkCore;

namespace Act5SweetBakary.Controllers
{
    public class HomeController : Controller
    {

        
        public IActionResult Index()
        {
            
            return View();

        }

        [Route("Productos")]
        public IActionResult Productos ()
        {
            sweetbakeryContext context = new sweetbakeryContext();
            var productos = context.Categorias.Include(x=>x.Productos).OrderBy(x=>x.Nombre);
            return View(productos);
        }

        [Route("Recetas")]
        public IActionResult Recetas()
        {
            sweetbakeryContext context = new sweetbakeryContext();
            var recetas = context.Categorias.Include(x => x.Receta).OrderBy(x => x.Nombre);
            return View(recetas);
        }



        //nombre = nombre.Replace("-", " ");
        //    sweetbakeryContext context = new sweetbakeryContext();
        //var r = context.Recetas.FirstOrDefault(x => x.Nombre == nombre);
        //    if (true)
        //    {

        //    }
        //    return View();
    }
}
