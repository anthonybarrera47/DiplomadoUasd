using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tarea2._5.Models;

namespace Tarea2._5.Controllers
{
    public class PeliculaController : Controller
    {
        // GET: Pelicula
        public ActionResult Index()
        {
            var Productos = new List<Producto>()
            {
                new Producto{Id=1,Descripcion="Boligrafo",Precio = 8.35},
                new Producto{Id=2,Descripcion="Cuaderno grande",Precio = 21.5},
                new Producto{Id=3,Descripcion="Cuaderno Pequeño",Precio = 10},
                new Producto{Id=4,Descripcion="Folios 500 uds.",Precio = 550.55},
                new Producto{Id=5,Descripcion="Grapadora",Precio = 85.25},
                new Producto{Id=6,Descripcion="Tijeras",Precio = 62},
                new Producto{Id=7,Descripcion="Cinta adhesiva",Precio = 45.10},
                new Producto{Id=8,Descripcion="Rotulador",Precio = 20.75},
                new Producto{Id=9,Descripcion="Mochila Escolar",Precio = 800.90},
                new Producto{Id=10,Descripcion="Pegamento barra",Precio = 30.15},
                new Producto{Id=11,Descripcion="Grapas",Precio = 15.55},
                new Producto{Id=1,Descripcion="Boligrafo",Precio = 8.35},
            };
            var ProductosContienenI = from producto in Productos
                                 where producto.Descripcion.Contains("I")
                                 select producto;
            var ProductosEmpiezanC = from producto in Productos
                                 where producto.Descripcion.StartsWith("C")
                                 select producto;
            var ProductosFinalizaConO = from producto in Productos
                                     where producto.Descripcion.EndsWith("O")
                                     select producto;
            var ProductosPrecioMayor20 = from producto in Productos
                                        where producto.Precio > 20
                                        select producto;
            var ProductosPrecioMenor70 = from producto in Productos
                                         where producto.Precio < 70
                                         select producto;
            return View(ProductosContienenI);
        }
    }
}