using Examen2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Controllers
{
    public class HomeController : Controller
    {
        private string name = "";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewBag.start = 1;
            ViewBag.login_failed = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login log)
        {
            string result = db_conn.LoginCheck(log);
            if (result != "")
            {
                ViewBag.start = 2;
                ViewBag.login_failed = 0;
                ViewBag.name = result;
                ViewBag.email = log.email;
                ViewBag.pass = log.password;
            }
            else
            {
                ViewBag.start = 1;
                ViewBag.login_failed = 1;
            }
            
            return View();
        }

        public IActionResult Visualizar(Login modo1)
        {
            using (tiendaContext db = new tiendaContext())
            {
                var articulos = db.Articulos.ToList();
                ViewBag.arts = articulos;
            }
            ViewBag.modo = modo1.modo;
            ViewBag.email = modo1.email;
            ViewBag.pass = modo1.password;
            return View();
        }
        public IActionResult Añadir(Login log)
        {
            ViewBag.email = log.email;
            ViewBag.pass = log.password;
            return View();
        }
        public IActionResult Insertar(Login art)
        {
            int result = db_conn.addArticulo(art);
            ViewBag.result = result;
            ViewBag.email = art.email;
            ViewBag.pass = art.password;
            return View();
        }

        public IActionResult Actualizar (Login art)
        {
            using (tiendaContext db = new tiendaContext())
            {
                var articulo = db.Articulos.Where(s => s.IdArticulo == art.IdArticulo).ToList();
                ViewBag.Nombre = articulo[0].Nombre;
                ViewBag.Precio = articulo[0].Precio;
                ViewBag.Iva = articulo[0].Iva;
                ViewBag.Cantidad = articulo[0].Cantidad;
            }
            ViewBag.IdArticulo = art.IdArticulo;
            
            ViewBag.email = art.email;
            ViewBag.pass = art.password;
            return View();
        }

        public IActionResult Update(Login art)
        {
            int result = db_conn.updateArticulo(art);
            ViewBag.result = result;
            ViewBag.email = art.email;
            ViewBag.pass = art.password;
            return View();
        }
        public IActionResult Delete(Login art)
        {
            int result = db_conn.deleteArticulo(art);
            ViewBag.result = result;
            ViewBag.email = art.email;
            ViewBag.pass = art.password;
            return View();
        }

    }
}
