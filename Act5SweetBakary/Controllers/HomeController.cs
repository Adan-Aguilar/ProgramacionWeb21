using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Act5SweetBakary.Models;

namespace Act5SweetBakary.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            sweetbakeryContext context = new sweetbakeryContext();
            return View();

        }
    }
}
