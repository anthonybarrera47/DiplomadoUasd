using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea2._6.Models;

namespace Tarea2._6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RegistroPelicula registro = new RegistroPelicula();
            return View(registro.GetAll());
        }
        public ActionResult Grabar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Grabar(FormCollection collection)
        {
            RegistroPelicula registro = new RegistroPelicula();
            Peliculas peli = new Peliculas
            {
                Codigo = int.Parse(collection["Codigo"]),
                Titulo = collection["Titulo"].ToString(),
                Director = collection["Director"].ToString(),
                AutorPrincipal = collection["AutorPrincipal"].ToString(),
                numAutores = int.Parse(collection["No_Autores"].ToString()),
                Duracion = double.Parse(collection["Duracion"].ToString()),
                Estreno = int.Parse(collection["Estreno"].ToString())
            };
            registro.GrabarPelicula(peli);
            return RedirectToAction("Index");
        }
        public ActionResult Borrar(int cod)
        {
            RegistroPelicula registro = new RegistroPelicula();
            registro.Borrar(cod);
            return RedirectToAction("Index");
        }
        public ActionResult Modificacion(int cod)
        {
            RegistroPelicula registro = new RegistroPelicula();
            Peliculas pelicula = registro.Recuperar(cod);
            return View(pelicula);
        }
        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            RegistroPelicula registro = new RegistroPelicula();
            Peliculas peli = new Peliculas
            {
                Codigo = int.Parse(collection["Codigo"]),
                Titulo = collection["Titulo"].ToString(),
                Director = collection["Director"].ToString(),
                AutorPrincipal = collection["AutorPrincipal"].ToString(),
                numAutores = int.Parse(collection["No_Autores"].ToString()),
                Duracion = double.Parse(collection["Duracion"].ToString()),
                Estreno = int.Parse(collection["Estreno"].ToString())
            };
            registro.Modificar(peli);
            return RedirectToAction("Index");
        }
    }
}