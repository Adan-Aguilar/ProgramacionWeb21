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

        [Route("Villancico/{nombre}")]
        public IActionResult Villancico(string nombre)
        {
            if (nombre == null)
            {
                return RedirectToAction("Index");
            }
            nombre = nombre.Replace("-", " ");
            villancicosContext context = new villancicosContext();
            
            var villancico = context.Villancicos.FirstOrDefault(x => x.Nombre==nombre);

            if (villancico == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(villancico);
            }

        }

        [Route("ingles")]
        public IActionResult Ingles()
        {
            

            villancicosContext context = new villancicosContext();
            

            var villancico = context.Villancicos

                
                
                .OrderBy(x => x.Nombre).Where(x => x.Idioma=="Inglés");

            return View(villancico);
        }

        [Route("español")]
        public IActionResult Español()
        {


            villancicosContext context = new villancicosContext();


            var villancico = context.Villancicos



                .OrderBy(x => x.Nombre).Where(x => x.Idioma == "Español");

            return View(villancico);
        }
    }
    
}
