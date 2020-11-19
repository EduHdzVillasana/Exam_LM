using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exam_LM.Models;
using Microsoft.Extensions.Configuration;
using Exam_LM.DataAccess;

namespace Exam_LM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _configuration = config;
        }

        public IActionResult Index()
        {
            // Read the value from the appsettings.json
            String connStr = _configuration.GetConnectionString("MyConnString");
            //ViewBag.conn = connStr;
            return View();
        }

        public IActionResult Page2(articuloModel articulo)
        {
            // Get the fruit model, and send it to the DataBase
            // Step 1 - Connect to the DB
            using (var context = new tiendaContext())
            {
                var articulos = context.Articulos.ToList().Take(10);
                ViewBag.art = articulos;
            }
            return View(articulo);
        }


    }
}
