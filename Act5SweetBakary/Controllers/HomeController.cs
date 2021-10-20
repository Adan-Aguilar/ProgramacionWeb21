using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act5SweetBakary.Models;
using Microsoft.EntityFrameworkCore;
using Act5SweetBakary.Models.ViewModels;

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
            var recetas = context.Categorias.Include(x => x.Receta).
                Where(x=>x.Receta.Any())
               .OrderBy(x => x.Nombre);
            return View(recetas);
        }

        [Route("Receta/{Nombre}")]
        public IActionResult Recetas(string nombre)
        {
            nombre = nombre.Replace("-", " ");
            sweetbakeryContext context = new sweetbakeryContext();
            var r = context.Recetas.FirstOrDefault(x => x.Nombre == nombre);
            if (r==null)
            {
                return RedirectToAction("Recetas");
            }

            else {
                RecetaViewModel vm = new RecetaViewModel(); 
                vm.Receta = r;
                Random rnd = new Random();
                var datos = context.Recetas
                    .Where(x=>x.Id!=r.Id)
                    .OrderBy(x => rnd.Next())
                    .Take(3)
                    .Select(x=> new Receta {Id=x.Id, Nombre=x.Nombre });
                
                return View(vm);

            }

           

        }


    }
}
