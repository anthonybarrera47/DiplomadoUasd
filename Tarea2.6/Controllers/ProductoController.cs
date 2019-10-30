using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea2._6.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            RegistroProductos registro = new RegistroProductos();
            return View(registro.GetAll()); 
        }
    }
}