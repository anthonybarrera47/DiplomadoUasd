using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea2._5.Models;

namespace Tarea2._5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Peliculas = new List<Pelicula>()
            {
                new Pelicula{Titulo="The GodFather",Director="Francis Ford Coppola",AutorPrincipal="Al pacino",numAutores=30,Duracion=2,Estreno=1994},
                new Pelicula{Titulo="The Shawshank",Director="Frank Darabont",AutorPrincipal="Morgan Freeman",numAutores=15,Duracion=3,Estreno=1972},
                new Pelicula{Titulo="The Matrix",Director="Lana Wachowski",AutorPrincipal="Keanu Reeves",numAutores=15,Duracion=2.30M,Estreno=1999},
                new Pelicula{Titulo="City od God",Director="Fernando Meirelles",AutorPrincipal="Alexandre Rodrigues",numAutores=10,Duracion=3,Estreno=2002},
                new Pelicula{Titulo="Star Wars: Episode IV",Director="George Lucas",AutorPrincipal="Harrison Ford",numAutores=20,Duracion=2.40M,Estreno=2007}

            };
            return View(Peliculas);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}