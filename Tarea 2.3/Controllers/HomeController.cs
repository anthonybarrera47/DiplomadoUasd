using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea_2._3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var Coches = new List<Coche>
            {
                new Coche{Tipo = "Jeep",Marca = "BMW",Modelo ="X6",Color ="Azul" },
                new Coche{Tipo = "Auto",Marca = "Mercedes",Modelo ="A200",Color ="Blanco" },
                new Coche{Tipo = "Jeep",Marca = "BMW",Modelo ="X6",Color ="Azul" },
                new Coche{Tipo = "Auto",Marca = "Ford",Modelo ="Mustang",Color ="Rojo" },
                };
            return View(Coches);
        }
    }
}