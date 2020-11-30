using Examen2.Models;
using Microsoft.AspNetCore.Http;
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
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // Entra al iniciar y después de hacer una operación
        {
            // Agarra los valores de login usando Session
            string email = HttpContext.Session.GetString("email");
            string pass = HttpContext.Session.GetString("pass");
            
            string result; // Se usa para saber si la contraseña es correcta
            
            
            if (email != null && pass != null)
            {
                Login log = new Login();
                log.email = email;
                log.password = pass;
                result = db_conn.LoginCheck(log); // Checa si la contraseña y email son correctos

                // ViewBag.start = {Login page: 1, Menu: 2 }
                // ViewBag.login_failed = {Login fallido: 0, Login exitoso:1}
                if (result != "")
                {
                    ViewBag.start = 2;
                    ViewBag.login_failed = 0;
                    ViewBag.name = result;

                    // Se agragan los datos de login a la sesion
                    HttpContext.Session.SetString("email", log.email);
                    HttpContext.Session.SetString("pass", log.password);
                }
                else
                {
                    ViewBag.start = 1;
                    ViewBag.login_failed = 1;
                }

            }
            else
            {
                ViewBag.start = 1;
                ViewBag.login_failed = 0;
            }

            int r; // Se usa para saber el resultado de una operación
            ViewBag.r = HttpContext.Session.GetInt32("Result");
            HttpContext.Session.SetInt32("Result", 0);
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login log) // Entra para validar por primera vez los datos de login
        {
            string result = db_conn.LoginCheck(log);
            if (result != "")
            {
                ViewBag.start = 2;
                ViewBag.login_failed = 0;
                ViewBag.name = result;
                HttpContext.Session.SetString("email", log.email);
                HttpContext.Session.SetString("pass", log.password);

            }
            else
            {
                ViewBag.start = 1;
                ViewBag.login_failed = 1;
            }
            ViewBag.r = HttpContext.Session.GetInt32("Result");
            HttpContext.Session.SetInt32("Result", 0);
            return View();
        }



        public IActionResult Visualizar(Login modo1) // Visualizar los articulos, modo decide si tendran boton de 
                                                     // actualizar, eliminar o nada (ver clase Login)
        {
            using (tiendaContext db = new tiendaContext()) // Select de articulos y los mete en un viewBag
            {
                var articulos = db.Articulos.ToList();
                ViewBag.arts = articulos;
            }
            ViewBag.modo = modo1.modo;
            return View();
        }
        public IActionResult Añadir()
        {
            return View();
        }
        public IActionResult Insertar(CRUD art) // Recibe datos de el articulo a incertar (Ver clase Crud)
        {
            int result = db_conn.addArticulo(art); // Ver clase db_conn
            if (result == 1)
            {
                HttpContext.Session.SetInt32("Result", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("Result", 2);
            }
            return RedirectToAction("Index"); // No necesita vista, se pasa directo (borrar vistas)
        }

        public IActionResult Actualizar (CRUD art)
        {
            using (tiendaContext db = new tiendaContext()) // Provisional, convertir en metodo de clase db_conn
            {
                var articulo = db.Articulos.Where(s => s.IdArticulo == art.IdArticulo).ToList();
                ViewBag.Nombre = articulo[0].Nombre;
                ViewBag.Precio = articulo[0].Precio;
                ViewBag.Iva = articulo[0].Iva;
                ViewBag.Cantidad = articulo[0].Cantidad;
            }
            ViewBag.IdArticulo = art.IdArticulo;
            return View();
        }

        public IActionResult Update(CRUD art) // Recibe los datos a actualizar
        {
            int result = db_conn.updateArticulo(art);
            if (result == 1)
            {
                HttpContext.Session.SetInt32("Result", 3);
            }
            else
            {
                HttpContext.Session.SetInt32("Result", 4);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(CRUD art) // Recibe los datos a eliminar (solo está el Id)
        {
            int result = db_conn.deleteArticulo(art);
            if (result == 1)
            {
                HttpContext.Session.SetInt32("Result", 5);
            }
            else
            {
                HttpContext.Session.SetInt32("Result", 6);
            }
            return RedirectToAction("Index");
        }

        public IActionResult LogOut ()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
