using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea2._3;

namespace Tarea2._3.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            var Personas = new List<Persona>()
            {
                new Persona { Nombre = "Juan", Apellidos = "Perez"},

                new Persona { Nombre = "Pedro", Apellidos = "Ramon"},

                new Persona { Nombre = "Homero", Apellidos = "Perez"},

                new Persona { Nombre = "Edward", Apellidos = "Perez"}
            };
            return View();
        }
    }
}