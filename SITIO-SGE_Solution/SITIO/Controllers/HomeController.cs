using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SITIO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "SGE (Sistema de Gestión Escolar) es un sitio web para administración y manejo de datos de un Centro Educativo.";

            return View();
        }

    }
}